using UnityEngine;
using UnityEngine.Rendering;

public class RenderMeshInstancedTest : MonoBehaviour {

    [SerializeField] private Mesh _mesh = null;
    [SerializeField] private Material _material = null;
    [SerializeField] private Vector2Int _count = new Vector2Int(10, 10);

    PositionBuffer _buffer;

    void Start() {

        _buffer = new PositionBuffer(_count.x, _count.y);
    
    }

    void OnDestroy() {
        _buffer.Dispose();
    }

    void Update() {

        _buffer.Update(Time.time);

        var matrices = _buffer.Matrices; 

        var rparams = new RenderParams(_material) {
            receiveShadows = true,
            shadowCastingMode = ShadowCastingMode.On 
        };

        for(var offs = 0; offs < matrices.Length; offs += 1023) {
            var count = Mathf.Min(1023, matrices.Length - offs);
            Graphics.RenderMeshInstanced(rparams, _mesh, 0, matrices, count, offs);
        }

    }
}
