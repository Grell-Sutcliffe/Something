using System;
using UnityEngine;

namespace BHSCamp
{
    [RequireComponent(typeof(AudioSource))]
    public class CharacterSound : MonoBehaviour
    {
        [SerializeField] private AudioClip _jumpSound;
        [SerializeField] private AudioClip _attackSound;
        [SerializeField] private AudioClip _hurtSound;
        [SerializeField] private AudioClip _runSound;
        [SerializeField] private AudioClip _deathSound;
        private AudioSource _audioSource;
        private Ground _ground;
        private float _inputX;
        private bool _isRunngin;

        [SerializeField] private AudioSource _stepAudioSource;

        private void Awake()
        {
            _ground = GetComponent<Ground>();
            _audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            //just started running
            if (_isRunngin == false && _ground.OnGround && _inputX != 0)
            {
                _isRunngin = true;
                _stepAudioSource.clip = _runSound;
                _stepAudioSource.Play();
            }
            //finish running or jump
            if (_isRunngin && (_ground.OnGround == false || _inputX == 0))
            {
                _isRunngin = false;
                _stepAudioSource.Stop();
            }
        }

        public void PlayJumpSound()
        {
            if (_jumpSound != null)
                _audioSource.PlayOneShot(_jumpSound);
        }

        public void PlayAttackSound()
        {
            if (_attackSound != null)
                _audioSource.PlayOneShot(_attackSound);
        }

        public void PlayHurtSound()
        {
            if (_hurtSound != null)
                _audioSource.PlayOneShot(_hurtSound);
        }

        public void PlayDeathSound()
        {
            if (_deathSound != null)
                _audioSource.PlayOneShot(_deathSound);
        }

        public void SetInputX(float inputX)
        {
            _inputX = inputX;
        }
    }
}