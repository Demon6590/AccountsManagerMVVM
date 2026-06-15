using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AccountsManagerMVVM.Components;

public partial class InputComponentPassword : UserControl
{
    public static readonly StyledProperty<object> LabelProperty =
        AvaloniaProperty.Register<InputComponentPassword, object>(nameof(Label));

    public object Label
    {
        get => GetValue(InputComponentPassword.LabelProperty);
        set => SetValue(InputComponentPassword.LabelProperty, value);
    }

    public static readonly StyledProperty<string?> ValueProperty =
        AvaloniaProperty.Register<InputComponentPassword, string?>(nameof(Value));

    public string? Value
    {
        get => this.GetValue<string?>(InputComponentPassword.ValueProperty);
        set => this.SetValue(InputComponentPassword.ValueProperty, value);
    }

    public static readonly StyledProperty<string?> PlaceholderProperty =
        AvaloniaProperty.Register<InputComponentPassword, string?>(nameof(Placeholder));

    public string? Placeholder
    {
        get => this.GetValue<string?>(InputComponentPassword.PlaceholderProperty);
        set => this.SetValue(InputComponentPassword.PlaceholderProperty, value);
    }

    public InputComponentPassword()
    {
        InitializeComponent();
    }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        if (change.Property == ValueProperty)
        {
            ValidatePassword(change.NewValue as string);
        }
    }

    private void ValidatePassword(string? text)
    {
        var textBox = this.FindControl<TextBox>("Input");
        if (textBox == null) return;


        if (string.IsNullOrEmpty(text))
        {
            DataValidationErrors.SetError(textBox, new Exception("Пароль не может быть пустым"));
            return;
        }


        if (text.Length < 8)
        {
            DataValidationErrors.SetError(textBox, new Exception("Длина должна быть не менее 8 символов"));
            return;
        }


        bool hasUpper = text.Any(char.IsUpper);
        bool hasLower = text.Any(char.IsLower);
        bool hasDigit = text.Any(char.IsDigit);


        if (!hasUpper)
        {
            DataValidationErrors.SetError(textBox,
                new Exception("Нужна минимум одна заглавная буква"));
            return;
        }

        if (!hasLower)
        {
            DataValidationErrors.SetError(textBox,
                new Exception("Нужна минимум одна строчная буква"));
            return;
        }

        if (!hasDigit)
        {
            DataValidationErrors.SetError(textBox,
                new Exception("Нужна минимум одна цифра"));
            return;
        }

        DataValidationErrors.ClearErrors(textBox);
    }

    public bool HasErrors => DataValidationErrors.GetHasErrors(this.FindControl<TextBox>("Input"));
}