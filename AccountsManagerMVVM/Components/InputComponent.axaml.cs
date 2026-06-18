using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AccountsManagerMVVM.Components;

public partial class InputComponent : UserControl
{
    public static readonly StyledProperty<object> LabelProperty =
        AvaloniaProperty.Register<InputComponent, object>(nameof(Label));

    public object Label
    {
        get => GetValue(InputComponent.LabelProperty);
        set => SetValue(InputComponent.LabelProperty, value);
    }

    public static readonly StyledProperty<string?> ValueProperty =
        AvaloniaProperty.Register<InputComponent, string?>(nameof(Value));

    public string? Value
    {
        get => this.GetValue<string?>(InputComponent.ValueProperty);
        set => this.SetValue(InputComponent.ValueProperty, value);
    }

    public static readonly StyledProperty<string?> PlaceholderProperty =
        AvaloniaProperty.Register<InputComponent, string?>(nameof(Placeholder));

    public string? Placeholder
    {
        get => this.GetValue<string?>(InputComponent.PlaceholderProperty);
        set => this.SetValue(InputComponent.PlaceholderProperty, value);
    }
    
    public static readonly StyledProperty<bool> HasErrorsProperty =
        AvaloniaProperty.Register<InputComponent, bool>(nameof(HasErrors), defaultValue: false);

    public bool HasErrors
    {
        get => GetValue(HasErrorsProperty);
        set => SetValue(HasErrorsProperty, value);
    }
    public InputComponent()
    {
        InitializeComponent();
    }
    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        if (change.Property == ValueProperty)
        {
            ValidateInput(change.NewValue as string);
        }
    }

    public void ValidateInput(string? text)
    {
        var textBox = this.FindControl<TextBox>("Input");
        if (textBox == null) return;


        if (string.IsNullOrWhiteSpace(text))
        {
            DataValidationErrors.SetError(textBox, new Exception("поле не может быть пустым"));
            HasErrors = true; 
            return;
        }
        
        DataValidationErrors.ClearErrors(textBox);
        HasErrors = false;
    }
    
}