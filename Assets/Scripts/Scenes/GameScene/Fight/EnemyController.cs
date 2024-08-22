using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Hero
{
    private GameObject _model;

    public Enemy Enemy { get; private set; }

    public void Spawn()
    {
        Vector2 position = ResourceManager.s_Instance.MapData.Position;

        List<Enemy> enemies = ResourceManager.s_Instance.Map[(int)position.x, (int)position.y].Enemies;
        Enemy = GetProbElement(enemies);

        _hpController.SetHP(Enemy.health, Enemy.health);
        MaxHP = Enemy.health;
        HP = Enemy.health;

        _model = Instantiate(Enemy.model, transform).gameObject;

        _hpController.gameObject.SetActive(true);
    }

    public void Delete()
    {
        Destroy(_model);
        _hpController.gameObject.SetActive(false);
    }

    protected override void Dead()
    {
        Delete();

        ResourceManager.s_Instance.Level.Experience += Enemy.experience;

        ResourceManager.s_Instance.Inventory.AddItem(GetProbElement(Enemy.loot));

        ResourceManager.s_Instance.MapData.PlusKill();

        Spawn();
    }

    private T GetProbElement<T>(List<T> elements) where T : class, IProbability, ICloneable
    {
        var total = 0f;
        foreach (var el in elements)
        {
            total += el.Probability;
        }

        var random = UnityEngine.Random.value * total;

        var current = 0f;
        foreach (var el in elements)
        {
            if (current <= random && random < current + el.Probability)
            {
                return el.Clone() as T;
            }
            current += el.Probability;
        }

        return null;
    }
}
