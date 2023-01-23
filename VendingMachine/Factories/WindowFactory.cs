using System;

namespace VendingMachine.Factories;

public class WindowFactory<TWindow>
{
    private readonly Func<TWindow> factory;

    public WindowFactory(Func<TWindow> factory)
    {
        this.factory = factory;
    }

    public TWindow Create()
    {
        return factory.Invoke();
    }
}