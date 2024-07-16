using System;
using UnityEngine;

/// <summary>
/// Detect the terrain under the GameObject
/// Play sounds using `PlayFootstep` e.g. from animation events
/// Based on https://alessandrofama.com/tutorials/fmod/unity/footsteps but much simpler
/// </summary>
public sealed class FootstepSounds : MonoBehaviour
{
    // must match the layer names in the project settings
    private enum SoundGameObjectLayer
    {
        None,
        Concrete,
        Normal,
        Gravel,
        Wood
    };
    
    // must match the terrain layers in the terrain (ordering)
    private enum SoundTerrainLayer
    {
        None,
        Normal,
        SpecialSound,
    };

    private SoundTerrainLayer _currentSoundTerrainLayer;
    private SoundGameObjectLayer _currentSoundGameObjectLayer;
    private FMOD.Studio.EventInstance _footsteps;
    private const float RaycastDistance = 2f;
    private TerrainData _terrainData;
    private int _alphamapWidth;
    private int _alphamapHeight;
    private float[,,] _splatmapData;
    private int _numTextures;

    private void Awake()
    {
        _terrainData = Terrain.activeTerrain.terrainData;
        _alphamapWidth = _terrainData.alphamapWidth;
        _alphamapHeight = _terrainData.alphamapHeight;
        _splatmapData = _terrainData.GetAlphamaps(0, 0, _alphamapWidth, _alphamapHeight);
        _numTextures = _splatmapData.Length / (_alphamapWidth * _alphamapHeight);
    }

    /// <summary>
    /// Call this method from animation events to trigger them
    /// </summary>
    public void PlayFootstep()
    {
        DetectTerrain();
        _footsteps = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/SFX_Footsteps");
        if (_currentSoundGameObjectLayer > 0)
        {
            _footsteps.setParameterByName("Terrain", (int)_currentSoundGameObjectLayer);
        }
        else if (_currentSoundTerrainLayer > 0)
        {
            _footsteps.setParameterByName("Terrain", (int)_currentSoundTerrainLayer + Enum.GetValues(typeof(SoundGameObjectLayer)).Length);
        }
        
        _footsteps.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        _footsteps.start();
        _footsteps.release();
    }
    
    private void DetectTerrain()
    {
        _currentSoundTerrainLayer = SoundTerrainLayer.None;
        _currentSoundGameObjectLayer = SoundGameObjectLayer.None;
        var rayHit = Physics.RaycastAll(transform.position, Vector3.down, RaycastDistance)[0];
        var layerName = LayerMask.LayerToName(rayHit.transform.gameObject.layer);
        if (Enum.TryParse(typeof(SoundGameObjectLayer), layerName, true, out var parsedTerrain))
        {
            _currentSoundGameObjectLayer = (SoundGameObjectLayer)parsedTerrain;
        }
        else
        {
            var terrainTextureId = GetActiveTerrainTextureIdx(rayHit.point);
            if (terrainTextureId >= 0)
            {
                _currentSoundTerrainLayer = (SoundTerrainLayer)(terrainTextureId + 1);
            }
            else
            {
                // fallback to concrete sounds
                _currentSoundGameObjectLayer = SoundGameObjectLayer.Concrete;
            }
        }
    }
 
    private Vector3 ConvertToSplatMapCoordinate(Vector3 worldPosition)
    {
        Vector3 splatPosition = new Vector3();
        Terrain ter = Terrain.activeTerrain;
        Vector3 terPosition = ter.transform.position;
        splatPosition.x = ((worldPosition.x - terPosition.x) / ter.terrainData.size.x) * ter.terrainData.alphamapWidth;
        splatPosition.z = ((worldPosition.z - terPosition.z) / ter.terrainData.size.z) * ter.terrainData.alphamapHeight;
        return splatPosition;
    }

    public int GetActiveTerrainTextureIdx(Vector3 position)
    {
        Vector3 terrainCord = ConvertToSplatMapCoordinate(position);
        int activeTerrainIndex = -1;
        float largestOpacity = 0f;

        for (int i = 0; i < _numTextures; i++)
        {
            if (largestOpacity < _splatmapData[(int)terrainCord.z, (int)terrainCord.x, i])
            {
                activeTerrainIndex = i;
                largestOpacity = _splatmapData[(int)terrainCord.z, (int)terrainCord.x, i];
            }
        }

        return activeTerrainIndex;
    }
}