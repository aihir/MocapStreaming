using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HipMovementTransfer : MonoBehaviour
{
    public Animator sourceAnimator; // 元となるアバターのAnimatorコンポーネント
    public GameObject targetGameObject; // データを流し込む対象のゲームオブジェクト

    void Update()
    {
        if (sourceAnimator == null || targetGameObject == null)
            return;

        // 元となるアバターのAnimatorコンポーネントから腰のボーンの位置と回転を取得
        Transform sourceHipTransform = sourceAnimator.GetBoneTransform(HumanBodyBones.Hips);
        Vector3 sourceHipPosition = sourceHipTransform.position;
        Quaternion sourceHipRotation = sourceHipTransform.rotation;

        // 腰のボーンの位置をx軸とz軸の値のみに置き換える
        Vector3 targetPosition = new Vector3(sourceHipPosition.x, targetGameObject.transform.position.y, sourceHipPosition.z);

        // 腰のボーンの回転からX軸とZ軸の回転を削除し、Y軸の回転に90度を加える
        Vector3 eulerRotation = sourceHipRotation.eulerAngles;
        eulerRotation.x = 0f;
        eulerRotation.y += 90f;
        eulerRotation.z = 0f;
        Quaternion targetRotation = Quaternion.Euler(eulerRotation);

        // 対象のゲームオブジェクトの位置と回転に適用
        targetGameObject.transform.position = targetPosition;
        targetGameObject.transform.rotation = targetRotation;
    }
}
