using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extension
{
    // LayerMask�� �Լ��� �߰������ִ� ���̱� ������ this �ٿ��ش�.
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