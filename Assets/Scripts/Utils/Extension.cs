using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extension
{
    // LayerMask에 함수를 추가시켜주는 것이기 때문에 this 붙여준다.
    public static bool Contain(this LayerMask layerMask, int layer)
    {
        return ((1 <<layer) & layerMask) != 0;
	}
    /*public void Test()
    {
        LayerMask mask;
        bool ret = mask.Contain(2);
    }*/
}