using UnityEngine;
using AustinHarris.JsonRpc;

// MODIFICATION: Changed from 'class' to 'struct'.
// This is now a value type, so 'new MyVector3()' does not create garbage.
public struct MyVector3
{
    public float x;
    public float y;
    public float z;

    public MyVector3(Vector3 v)
    {
        this.x = v.x;
        this.y = v.y;
        this.z = v.z;
    }
}

public class Sub : MonoBehaviour
{
    class Rpc : JsonRpcService
    {
        private readonly Sub sub; // Using 'readonly' is good practice for fields set in the constructor.

        public Rpc(Sub sub)
        {
            this.sub = sub;
        }

        [JsonRpcMethod]
        void Say(string message)
        {
            Debug.Log("Sub says: " + message);
        }

        [JsonRpcMethod]
        float getHeight()
        {
            return sub.transform.position.y;
        }

        [JsonRpcMethod]
        MyVector3 getPos()
        {
            // NO MODIFICATION NEEDED HERE.
            // Because MyVector3 is a struct, this call does not allocate on the heap.
            // It simply initializes a value on the stack which is then copied for the return.
            return new MyVector3(sub.transform.position);
        }
    }

    Rpc rpc;

    void Start()
    {
        rpc = new Rpc(this);
    }

    // Update is called once per frame
    void Update()
    {
        // No changes needed
    }
}