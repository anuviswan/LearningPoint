One of the projects I have in mind as my side-projects needs ability to drag-move shapes on a Canvas. I thought it would idea to explore the possibilities of achieving it via test projects first before starting the real one. So the goal of this article would be 
* Create a Rectangle in a Canvas
* Support ability to Drag-move it within the Canvas boundary

Let's begin by defining the basic UI including our Canvas and Rectange. We would be using Caliburn Micro for supporting MVVM in the example.

```xml
<Canvas Grid.Row="2" Background="AliceBlue" >
    <Rectangle Height="100" Width="100" Fill="Red" Canvas.Left="{Binding Left}" Canvas.Top="{Binding Top}"  />
</Canvas>
```

Our ViewModel, at the moment looks like,
```csharp
public class ShellViewModel:PropertyChangedBase
{
    public double Left { get; set; } = 10;
    public double Top { get; set; } = 10;
}
```

The `Left` and `Top` are double properties which will have the position of the `Rectange` with respect to the `Canvas`.

The next step is to capture the Mouse Position each time the User holds the Left Mouse Button down and drags the object. For this there are few things needs to be done. We need to detect when the Left Mouse Button is pressed down and released. Also, we need to trace the Mouse Position when the User holds the Left Mouse Down within the rectangle.

To detect the mouse position, we will write a Behavior.

```csharp
public class MouseMoveBehavior:Behavior<Canvas>
{
    public double MouseTop
    {
        get { return (double)GetValue(MouseTopProperty); }
        set { SetValue(MouseTopProperty, value); }
    }

    public static readonly DependencyProperty MouseTopProperty =
        DependencyProperty.Register("MouseTop", typeof(double), typeof(MouseMoveBehavior), new PropertyMetadata(0d));

    public double MouseLeft
    {
        get { return (double)GetValue(MouseLeftProperty); }
        set { SetValue(MouseLeftProperty, value); }
    }

    public static readonly DependencyProperty MouseLeftProperty =
        DependencyProperty.Register("MouseLeft", typeof(double), typeof(MouseMoveBehavior), new PropertyMetadata(0d));

    protected override void OnAttached()
    {
        AssociatedObject.MouseMove += AssociatedObject_MouseMove;
    }

    private void AssociatedObject_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
    {
        var currentPosition = e.GetPosition(AssociatedObject);
        MouseLeft = currentPosition.X;
        MouseTop = currentPosition.Y;
    }

    protected override void OnDetaching()
    {
        AssociatedObject.MouseMove -= AssociatedObject_MouseMove;
    }
}
```

The Behavior `MouseMoveBehavior` defines two Dependency Properties named `MouseTop` and `MouseLeft` indicating the X-Y cordinates of the mouse position. The behavior intends to capture the Mouse position using the `MouseEventArgs.GetPosition` and update the dependency properties with the Position.X and Position.Y values. 

So, we have our behavior in place. Now is the time to update our Xaml to use our Behavior.

```xml
<Canvas Grid.Row="2" Background="AliceBlue" cal:Message.Attach="[Event MouseMove]=[Action MouseMove]; 
        [Event PreviewMouseLeftButtonUp]=[Action MouseUp];[Event MouseLeave]=[Action MouseUp]" >
    <i:Interaction.Behaviors>
        <behaviors:MouseMoveBehavior MouseLeft="{Binding Left,Mode=TwoWay}" MouseTop="{Binding Top,Mode=TwoWay}"/>
    </i:Interaction.Behaviors>
    <Rectangle Height="100" Width="100" Fill="Red" Canvas.Left="{Binding Left}" Canvas.Top="{Binding Top}" cal:Message.Attach="[Event PreviewMouseLeftButtonDown]=[Action MouseDown]" />
</Canvas>
```

As you can observe, we are updating the `Left` and `Top` properties by capturing them in Behavior and assigning the the values of current mouse position. This would ensure the the shape would move along the mouse pointer.

But you want to 
