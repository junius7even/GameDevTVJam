using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Effect
{
    public class ParallaxEffect : MonoBehaviour
    {
        [SerializeField] Vector2 parallaxSpeed;
        [SerializeField]bool infiniteHorizontal;
        [SerializeField]bool infiniteVertical;
        private Transform cameraTransform;
        private Vector3 lastCameraPosition;
        float textureUnitSizeX;
        float textureUnitSizeY;

        private void Start()
        {
            cameraTransform = Camera.main.transform;
            lastCameraPosition = cameraTransform.position;
            Sprite sprite = GetComponent<SpriteRenderer>().sprite;
            Texture2D texture = sprite.texture;
            textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
            textureUnitSizeY = texture.height / sprite.pixelsPerUnit;

        }
        private void Update()
        {
            Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;

            transform.position += new Vector3(deltaMovement.x * parallaxSpeed.x, deltaMovement.y * parallaxSpeed.y);
            lastCameraPosition = cameraTransform.position;

            if(infiniteHorizontal)
            {
                if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX)
                {
                    float offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
                    transform.position = new Vector2(cameraTransform.position.x + offsetPositionX, transform.position.y);
                }
            }

            if(infiniteVertical)
            {
                if (Mathf.Abs(cameraTransform.position.y - transform.position.y) >= textureUnitSizeY)
                {
                    float offsetPositionY = (cameraTransform.position.y - transform.position.y) % textureUnitSizeY;
                    transform.position = new Vector2(transform.position.x, cameraTransform.position.y + offsetPositionY);
                }
            }            
        }
    }
}
