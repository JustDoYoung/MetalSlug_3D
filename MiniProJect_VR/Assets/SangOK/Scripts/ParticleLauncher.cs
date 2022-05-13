using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLauncher : MonoBehaviour
{
    //�Ѿ��� �߻�Ǵ� ��ƼŬ ��ü  
    public ParticleSystem particleLauncher;

    //�߻�� �Ѿ˰�ü�� ���� �浹�ɶ� ȣ��Ǵ� �浹���� ����Ʈ
    public ParticleSystem splatterParticles;

    //�浹�ϴ� �̺�Ʈ���� ������ , ��ƼŬ �̺�Ʈ ���� ����Ʈ 
    List<ParticleCollisionEvent> collisionEvents;
    public Gradient particleColorGradient;

    public void Start()
    {
        collisionEvents = new List<ParticleCollisionEvent>();
    }
    //����Ƽ���� �̸� �����Ǵ� �̺�Ʈ ���� �Լ��ν�,��ƼŬ �浹�� ��Ʈ�� �����Ѵ�.
    void OnParticleCollision(GameObject other)
    {
        //�ش� ��ƼŬ �ý����� �̺�Ʈ�� �����ϰ�, �̺�Ʈ ���������� �ش� ����Ʈ�� �浹�ø��� ���Ҵ��Ѵ�.
        ParticlePhysicsExtensions.GetCollisionEvents(particleLauncher, other, collisionEvents);

        //������ ��ƼŬ �̺�Ʈ�� ������, �ش� �����ǿ��� ��ƼŬ�� ����Ʈ ��Ų��.
        for (int i = 0; i < collisionEvents.Count; i++)
        {
            EmitAtLocation(collisionEvents[i]);
        }
    }
    void EmitAtLocation(ParticleCollisionEvent particleCollisionEvent)
    {
        //��ƼŬ�� ��ġ�� �����̼ǰ��� ���� �����ؼ� ��������.
        splatterParticles.transform.position = particleCollisionEvent.intersection;//�̺�Ʈ�� ������ ���� 
        //�̺�Ʈ�� , �浹�� ��ü�� �븻 ���� ���� ������ ������.
        splatterParticles.transform.rotation = Quaternion.LookRotation(particleCollisionEvent.normal);

        //������ ���� �����Ҽ� ���⶧����, �Ʒ��� ���� ���� ������ ���غ����Ѵ�.
        ParticleSystem.MainModule psMain = splatterParticles.main;
        psMain.startColor = particleColorGradient.Evaluate(Random.Range(0f, 1f));

        //�ϳ��� �̺�Ʈ������ �ϳ��� ��ƼŬ�� ����Ʈ 
        splatterParticles.Emit(1);
    }
    //���콺 ��ǲ�� ���� ��ƼŬ�� �߻��ϴ� �Լ� 
    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            //���� �ϰ��� �ϴ� ��ƼŬ�� ������, �Ӽ��� ��ȭ ��Ű�� ���
            ParticleSystem.MainModule psMain = particleLauncher.main;
            psMain.startColor = Color.red;
            //�Ѿ� ��ƼŬ �߻� 
            particleLauncher.Emit(1);
        }
    }
}