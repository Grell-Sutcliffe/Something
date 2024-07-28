using BHSCamp.FSM;
using UnityEngine;

namespace BHSCamp
{
    public class DeadState : FsmState
    {
        //protected Healthbar _healthbar;
        //protected Health _health;
        //protected Collider2D _collider;

        private PatrolEnemy _enemy;
        private Animator _animator;
        private bool _respawn;
        private float _respawnTime;
        private float _timer;

        public DeadState(Fsm fsm, PatrolEnemy enemy, bool respawn, float respawnTime) : base(fsm)
        {
            //_healthbar = enemy.GetComponent<Healthbar>();
            //_health = enemy.GetComponent<Health>();

            //_collider = enemy.GetComponent<Collider2D>();

            _respawn = respawn;
            _respawnTime = respawnTime;
            _animator = enemy.GetComponent<Animator>();
            _enemy = enemy;
        }

        public override void Enter()
        {
            //_collider.isTrigger = true;

            _animator.SetBool("IsDead", true);
            _timer = 0;
        }

        public override void Update(float deltaTime)
        {
            if (!_respawn) return;
            _timer += deltaTime;
            if (_timer > _respawnTime)
                Fsm.SetState<PatrolState>();
            //if (_healthbar.isActiveAndEnabled) 
            //    _healthbar.UpdateHealthbar(_health.MaxHealth);
        }

        public override void Exit()
        {
            //_collider.isTrigger = false;

            _animator.SetBool("IsDead", false);
            Health health = _enemy.GetComponent<Health>();
            health.Heal(health.MaxHealth);
            //if (_healthbar.isActiveAndEnabled)
            //    _healthbar.UpdateHealthbar(_health.MaxHealth);
        }
    }
}