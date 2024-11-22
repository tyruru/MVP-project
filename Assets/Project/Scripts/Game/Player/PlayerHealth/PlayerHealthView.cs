using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerHealthView : HealthView
{
    private Slider _hpBar;
    [SerializeField] private string[] _targets;

    private void Awake()
    {
        _hpBar = GameObject.FindGameObjectWithTag("playerHpSlider").GetComponent<Slider>();
        //Если сцена с игроком загружается, всегде должно идти время
        Time.timeScale = 1f;
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        foreach (var tag in _targets)
            if (target.gameObject.CompareTag(tag))
            {
                Vector2 targetTransform = target.transform.position;

                // Проверяем, что столкновение произошло с Tilemap
                if (target.collider.CompareTag("Obstacle"))
                {
                    Tilemap tilemap = target.collider.GetComponent<Tilemap>();

                    if (tilemap != null)
                    {
                        // Определяем точку контакта
                        ContactPoint2D contactPoint = target.GetContact(0);
                        Vector3 contactWorldPosition = contactPoint.point;

                        // Конвертируем мировую позицию в позицию плитки
                        Vector3Int tilePosition = tilemap.WorldToCell(contactWorldPosition);

                        // Преобразуем позицию плитки обратно в мировую для получения точной позиции
                        Vector3 tileWorldPosition = tilemap.GetCellCenterWorld(tilePosition);

                        targetTransform = new Vector2(tileWorldPosition.x, tileWorldPosition.y);
                    }
                }

                TakeDamage(1, targetTransform);
            }
    }

    public override void ChangeView(float hpPercent)
    {
        //Debug.Log("View: Percent is:" + hpPercent);
        _hpBar.value = hpPercent;
    }
}
