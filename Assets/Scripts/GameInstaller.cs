using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PlayerDataSaver>().FromNew().AsSingle().NonLazy();
    }
}