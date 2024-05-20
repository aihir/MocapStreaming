using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HipMovementTransfer : MonoBehaviour
{
    public Animator sourceAnimator; // ���ƂȂ�A�o�^�[��Animator�R���|�[�l���g
    public GameObject targetGameObject; // �f�[�^�𗬂����ޑΏۂ̃Q�[���I�u�W�F�N�g

    void Update()
    {
        if (sourceAnimator == null || targetGameObject == null)
            return;

        // ���ƂȂ�A�o�^�[��Animator�R���|�[�l���g���獘�̃{�[���̈ʒu�Ɖ�]���擾
        Transform sourceHipTransform = sourceAnimator.GetBoneTransform(HumanBodyBones.Hips);
        Vector3 sourceHipPosition = sourceHipTransform.position;
        Quaternion sourceHipRotation = sourceHipTransform.rotation;

        // ���̃{�[���̈ʒu��x����z���̒l�݂̂ɒu��������
        Vector3 targetPosition = new Vector3(sourceHipPosition.x, targetGameObject.transform.position.y, sourceHipPosition.z);

        // ���̃{�[���̉�]����X����Z���̉�]���폜���AY���̉�]��90�x��������
        Vector3 eulerRotation = sourceHipRotation.eulerAngles;
        eulerRotation.x = 0f;
        eulerRotation.y += 90f;
        eulerRotation.z = 0f;
        Quaternion targetRotation = Quaternion.Euler(eulerRotation);

        // �Ώۂ̃Q�[���I�u�W�F�N�g�̈ʒu�Ɖ�]�ɓK�p
        targetGameObject.transform.position = targetPosition;
        targetGameObject.transform.rotation = targetRotation;
    }
}
