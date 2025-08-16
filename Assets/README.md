# UI.Windows - Фреймворк для Unity UI

![Unity Version](https://img.shields.io/badge/Unity-2019.1%2B-blue)
![Version](https://img.shields.io/badge/Version-1.2.7-green)
![License](https://img.shields.io/badge/License-MIT-orange)

## 🤔 Что это вообще такое и зачем?

**UI.Windows** - это **продвинутый фреймворк для создания пользовательских интерфейсов в Unity**. Представь, что ты делаешь игру и тебе нужно создать кучу экранов: главное меню, настройки, инвентарь, магазин, диалоги и всё такое. Без фреймворка это превращается в адский ад - куча дублированного кода, переходы между экранами работают криво, анимации глючат, а когда проект разрастается, ты уже не понимаешь где что лежит.

**UI.Windows решает ВСЕ эти проблемы** и даёт тебе готовую архитектуру, где всё организовано правильно с самого начала.

### 🎯 Главная идея - думай как веб-разработчик

Фреймворк использует концепцию **"Экран/Макет/Компонент"** - по сути, это как веб-страницы:

- **Экран (Screen)** = веб-страница (главное меню, настройки, инвентарь)
- **Макет (Layout)** = HTML-разметка страницы (где что расположено)  
- **Компонент (Component)** = элементы на странице (кнопки, текст, картинки)

Только всё это работает в Unity и заточено под игры.

## 📋 Содержание

- [Что это и зачем?](#-что-это-вообще-такое-и-зачем)
- [Установка](#-установка-по-шагам)
- [Быстрый старт](#-быстрый-старт-делаем-первый-экран)
- [Как это работает?](#-как-это-работает-архитектура)
- [Экраны](#-экраны-screens---основа-всего)
- [Макеты](#-макеты-layouts---разметка-экранов)
- [Компоненты](#-компоненты-components---кирпичики-интерфейса)
- [Анимации](#-анимации-делаем-красиво)
- [Встроенные модули](#-встроенные-модули-готовые-решения)
- [Инструменты редактора](#️-инструменты-редактора)
- [Примеры](#-примеры-от-простого-к-сложному)
- [Решение проблем](#-решение-проблем)

## 🚀 Установка по шагам

### Способ 1: Через Package Manager (рекомендуется)

1. Открой Unity
2. Иди в **Window → Package Manager**
3. Нажми **+** (плюсик) в левом верхнем углу
4. Выбери **Add package from git URL**
5. Вставь: `https://github.com/chromealex/UI.Windows-submodule.git`
6. Нажми **Add**
7. Подожди пока Unity всё установит

### Способ 2: Ручная установка

1. Скачай репозиторий как ZIP
2. Распакуй в папку `Packages` твоего проекта
3. Unity автоматически подхватит пакет

### Что ещё нужно?

Фреймворк автоматически установит эти зависимости:
- **Unity Addressables** (для загрузки ресурсов)
- **Unity Localization** (для многоязычности)
- **Unity UI Toolkit** (для современного UI)

Не паникуй, если видишь ошибки после установки - это нормально, пока ты не настроишь систему.

## ⚡ Быстрый старт - делаем первый экран

### Шаг 1: Создай WindowSystem

Это главный мозг всей UI-системы. Без него ничего работать не будет.

1. **Правой кнопкой** в иерархии сцены
2. **Create Empty** (создай пустой объект)
3. Назови его `WindowSystem`
4. Добавь компонент **Window System** (найди через Add Component)

Или ещё проще:
1. В меню Unity: **GameObject → UI → Window System**

### Шаг 2: Создай свой первый экран

Используй встроенный мастер создания экранов:

1. **Правой кнопкой** в папке проекта
2. **Create → UI.Windows → Screen**
3. Назови экран, например `MainMenuScreen`

**ВНИМАНИЕ!** Мастер автоматически создаст:
- Скрипт экрана `MainMenuScreen.cs`
- Префаб макета `MainMenuLayout.prefab`
- Папку для компонентов `MainMenuComponents/`

### Шаг 3: Напиши код экрана

Открой созданный файл `MainMenuScreen.cs`:

```csharp
using UnityEngine;
using UnityEngine.UI.Windows;

public class MainMenuScreen : WindowBase
{
    // Здесь мы ссылаемся на компоненты экрана
    [SerializeField] private ButtonComponent playButton;
    [SerializeField] private ButtonComponent settingsButton;
    [SerializeField] private ButtonComponent exitButton;

    // Вызывается когда экран полностью показался
    public override void OnShowEnd()
    {
        // Настраиваем кнопку "Играть"
        playButton.SetCallback(() => {
            Debug.Log("Игрок нажал Играть!");
            // Здесь можно перейти на экран игры
            // WindowSystem.Show<GameScreen>();
        });

        // Настраиваем кнопку "Настройки"
        settingsButton.SetCallback(() => {
            Debug.Log("Открываем настройки!");
            // WindowSystem.Show<SettingsScreen>();
        });

        // Настраиваем кнопку "Выход"
        exitButton.SetCallback(() => {
            Debug.Log("Выходим из игры!");
            Application.Quit();
        });
    }
}
```

### Шаг 4: Настрой макет

1. Открой созданный префаб `MainMenuLayout.prefab`
2. Увидишь Canvas с компонентом **Window Layout**
3. Добавь UI элементы (кнопки, текст, картинки)
4. Преобразуй обычные Button в **ButtonComponent**:
   - Выбери кнопку
   - Add Component → **Button Component**
   - Удали обычный Button
5. Настрой ссылки в **Window Layout** на твои компоненты

### Шаг 5: Покажи экран

В любом месте кода (например, в Start() какого-то скрипта):

```csharp
using UnityEngine.UI.Windows;

public class GameStarter : MonoBehaviour
{
    void Start()
    {
        // Показываем главное меню
        WindowSystem.Show<MainMenuScreen>();
    }
}
```

**ПОЗДРАВЛЯЮ!** Ты создал свой первый экран с помощью UI.Windows!

## 🏗️ Как это работает? (Архитектура)

### Основная концепция - трёхуровневая модель

Представь многоэтажный дом:

#### 🏢 **Экраны (Screens)** - это этажи дома
- **Что это?** Целые страницы интерфейса
- **Примеры:** Главное меню, инвентарь, настройки, диалог с NPC
- **Основа:** Класс `WindowBase`
- **Зачем?** Управляют логикой всего экрана, переходами, состоянием

```csharp
// Экран - это как отдельная веб-страница
public class InventoryScreen : WindowBase
{
    // Логика всего экрана инвентаря
    public override void OnShowBegin()
    {
        LoadPlayerItems(); // Загружаем предметы игрока
        UpdateGoldDisplay(); // Показываем золото
    }
}
```

#### 🏠 **Макеты (Layouts)** - это планировка этажа
- **Что это?** Canvas с расположением элементов
- **Основа:** Компонент `WindowLayout`
- **Зачем?** Определяют где что находится, настройки Canvas, безопасные зоны

```csharp
// Макет - это как HTML-разметка страницы
// Настраивается в редакторе Unity как префаб
// Содержит Canvas, CanvasScaler, WindowLayout
```

#### 🪑 **Компоненты (Components)** - это мебель в комнатах
- **Что это?** Отдельные UI элементы
- **Примеры:** Кнопки, текст, картинки, списки, слайдеры
- **Основа:** Класс `WindowComponent`
- **Зачем?** Переиспользуемые кусочки интерфейса с логикой

```csharp
// Компонент - это как элемент на веб-странице
public class InventorySlotComponent : WindowComponent
{
    // Логика одного слота инвентаря
    public void SetItem(Item item)
    {
        icon.sprite = item.icon;
        nameText.text = item.name;
    }
}
```

### Как они взаимодействуют?

```
WindowSystem (главный мозг)
    ↓
MainMenuScreen (экран)
    ↓
MainMenuLayout (макет - Canvas с кнопками)
    ↓
ButtonComponent, TextComponent (компоненты)
```

**В реальности:**
1. **WindowSystem** управляет всеми экранами
2. **Screen** содержит логику страницы
3. **Layout** содержит визуальную разметку
4. **Components** - это переиспользуемые элементы

## 🖥️ Экраны (Screens) - основа всего

### Что такое экран?

**Экран** - это как отдельная страница в приложении. Главное меню - экран, настройки - экран, инвентарь - экран, диалог с NPC - тоже экран.

### Жизненный цикл экрана

Каждый экран проходит через определённые этапы:

```csharp
public class MyScreen : WindowBase
{
    // 1. Экран создался, но ещё не видим
    public override void OnInitialize()
    {
        Debug.Log("Экран создался, настраиваем начальные значения");
    }

    // 2. Начинаем показывать экран (запускаются анимации появления)
    public override void OnShowBegin()
    {
        Debug.Log("Начинаем показывать экран");
        LoadData(); // Загружаем данные
    }

    // 3. Экран полностью показался
    public override void OnShowEnd()
    {
        Debug.Log("Экран полностью видим, можно взаимодействовать");
        SetupButtons(); // Настраиваем кнопки
    }

    // 4. Начинаем скрывать экран
    public override void OnHideBegin()
    {
        Debug.Log("Начинаем скрывать экран");
        SaveData(); // Сохраняем данные
    }

    // 5. Экран полностью скрылся
    public override void OnHideEnd()
    {
        Debug.Log("Экран скрылся, освобождаем ресурсы");
        CleanupData();
    }
}
```

### Основные методы экрана

#### Навигация между экранами

```csharp
public class MainMenuScreen : WindowBase
{
    public void OnPlayButtonClick()
    {
        // Показать экран игры
        WindowSystem.Show<GameScreen>();
        
        // Скрыть текущий экран
        WindowSystem.Hide<MainMenuScreen>();
        
        // Или одной строкой - скрыть текущий и показать новый
        WindowSystem.Show<GameScreen>();
        WindowSystem.Hide(this);
    }

    public void OnSettingsButtonClick()
    {
        // Показать настройки поверх главного меню (как оверлей)
        var parameters = new ScreenItem().SetAsOverlay(true);
        WindowSystem.Show<SettingsScreen>(parameters);
    }
}
```

#### Передача параметров между экранами

```csharp
// Отправляем параметры
public void OpenShop()
{
    var shopData = new ShopParameters 
    { 
        shopType = ShopType.Weapons,
        playerGold = 1000 
    };
    
    var parameters = new ScreenItem().SetParameters(shopData);
    WindowSystem.Show<ShopScreen>(parameters);
}

// Получаем параметры
public class ShopScreen : WindowBase
{
    public override void OnParametersPass(ScreenItem item)
    {
        var shopData = item.GetParameter<ShopParameters>();
        SetupShop(shopData.shopType);
        UpdateGoldDisplay(shopData.playerGold);
    }
}
```

### Состояния экрана

Каждый экран имеет состояние:

- **NotInitialized** - экран ещё не создан
- **Initializing** - экран создаётся
- **Showing** - экран появляется (идёт анимация)
- **Shown** - экран полностью видим
- **Hiding** - экран исчезает (идёт анимация)
- **Hidden** - экран скрыт

```csharp
// Проверить состояние экрана
if (WindowSystem.GetScreen<MainMenuScreen>().GetState() == ObjectState.Shown)
{
    Debug.Log("Главное меню видимо");
}

// Проверить видимость экрана
if (WindowSystem.IsVisible<MainMenuScreen>())
{
    Debug.Log("Главное меню видимо");
}
```

## 🎨 Макеты (Layouts) - разметка экранов

### Что такое макет?

**Макет** - это префаб с Canvas, который определяет как выглядит экран. Это как HTML-страница - содержит разметку, но не содержит логику.

### Структура макета

Типичный макет выглядит так:

```
MainMenuLayout (префаб)
├── Canvas
│   ├── WindowLayout (компонент)
│   ├── Background (Image)
│   ├── Title (Text)
│   ├── ButtonsPanel
│   │   ├── PlayButton (ButtonComponent)
│   │   ├── SettingsButton (ButtonComponent)
│   │   └── ExitButton (ButtonComponent)
│   └── Footer (Text)
```

### Настройка макета

1. **Создай макет** через мастер или вручную
2. **Добавь Canvas** если его нет
3. **Добавь WindowLayout** компонент на Canvas
4. **Настрой Canvas:**
   - Render Mode (обычно Screen Space - Overlay)
   - Canvas Scaler настройки
   - Sorting Order для слоёв

### WindowLayout компонент

Этот компонент управляет макетом:

```csharp
public class WindowLayout : MonoBehaviour
{
    // Ссылки на компоненты экрана
    [SerializeField] private WindowComponent[] components;
    
    // Настройки Canvas
    [SerializeField] private Canvas canvas;
    [SerializeField] private CanvasScaler canvasScaler;
    
    // Безопасные зоны для мобильных устройств
    [SerializeField] private WindowLayoutSafeZone safeZone;
}
```

### Безопасные зоны

Для мобильных устройств важно учитывать вырезы экрана (notch):

```csharp
// WindowLayoutSafeZone автоматически адаптирует UI
// под безопасные зоны iPhone X+ и Android с вырезами
```

### Слои и порядок отображения

```csharp
// В WindowSystem можно настроить слои
var parameters = new ScreenItem()
    .SetLayer(0)        // Фоновый слой
    .SetDepth(100);     // Глубина в слое

WindowSystem.Show<BackgroundScreen>(parameters);

var parameters2 = new ScreenItem()
    .SetLayer(1)        // Основной UI слой
    .SetDepth(200);     

WindowSystem.Show<MainMenuScreen>(parameters2);

var parameters3 = new ScreenItem()
    .SetLayer(2)        // Оверлеи
    .SetDepth(300);

WindowSystem.Show<SettingsScreen>(parameters3);
```

## 🧩 Компоненты (Components) - кирпичики интерфейса

### Что такое компонент?

**Компонент** - это переиспользуемый элемент интерфейса. Кнопка, текст, картинка, слайдер - всё это компоненты. Главная фича - они умные и содержат логику.

### Встроенные компоненты

#### 🔘 ButtonComponent - умная кнопка

```csharp
public class MenuButtonComponent : ButtonComponent
{
    // Переопределяем поведение клика
    public override void OnClick()
    {
        Debug.Log("Кнопка нажата!");
        
        // Получаем доступ к экрану
        var screen = GetWindow<MainMenuScreen>();
        screen.OnButtonClicked();
    }

    // Настройка кнопки из кода
    public void Setup()
    {
        SetText("Играть");
        SetInteractable(true);
        SetCallback(() => Debug.Log("Callback сработал!"));
    }

    // Реакция на наведение мыши
    protected override void OnHover()
    {
        // Анимация при наведении
        transform.localScale = Vector3.one * 1.1f;
    }

    protected override void OnUnhover()
    {
        // Возвращаем размер
        transform.localScale = Vector3.one;
    }
}
```

**Дополнительные модули для кнопок:**
- **ButtonLongPressComponentModule** - долгое нажатие
- **DoublePressComponentModule** - двойной клик  
- **HoverComponentModule** - эффекты при наведении
- **PlaySfxOnClickComponentModule** - звук при клике

#### 📝 TextComponent - умный текст

```csharp
public class ScoreTextComponent : TextComponent
{
    public void SetScore(int score)
    {
        SetText($"Очки: {score}");
    }

    public void AnimateScore(int newScore)
    {
        // Анимированное изменение числа
        var module = GetModule<TextComponentModuleAnimateValue>();
        module.AnimateToValue(newScore, 1f); // за 1 секунду
    }

    public void SetLocalizedText(string key)
    {
        // Локализованный текст
        var locModule = GetModule<TextLocalizationComponentModule>();
        locModule.SetLocalizedKey(key);
    }
}
```

#### 🖼️ ImageComponent - умная картинка

```csharp
public class ItemIconComponent : ImageComponent
{
    public void LoadItemIcon(string itemId)
    {
        // Загружаем спрайт из ресурсов
        var resourceModule = GetModule<ResourceSpriteLoadModule>();
        resourceModule.LoadSprite($"Items/{itemId}_icon");
    }

    public void SetColor(Color color)
    {
        GetComponent<Image>().color = color;
    }

    public void FadeIn(float duration = 0.5f)
    {
        // Плавное появление
        var image = GetComponent<Image>();
        var color = image.color;
        color.a = 0f;
        image.color = color;

        Tweener.DoFloat(0f, 1f, duration, (alpha) => {
            color.a = alpha;
            image.color = color;
        });
    }
}
```

#### 📋 ListComponent - умный список

Это самый мощный компонент - умеет работать с коллекциями данных:

```csharp
// Данные для списка
[System.Serializable]
public class InventoryItem
{
    public string name;
    public Sprite icon;
    public int count;
    public bool isUsable;
}

// Компонент списка
public class InventoryListComponent : ListComponent<InventoryItem>
{
    // Привязываем данные к элементу списка
    protected override void OnDataBind(InventoryItem item, int index)
    {
        // Получаем компонент элемента списка по индексу
        var slot = GetComponentAtIndex<InventorySlotComponent>(index);
        
        // Настраиваем элемент
        slot.SetItem(item);
        slot.SetClickCallback(() => UseItem(item));
    }

    // Обновляем данные списка
    public void RefreshInventory()
    {
        var playerItems = GameManager.GetPlayerItems();
        SetData(playerItems); // Автоматически обновит весь список
    }

    private void UseItem(InventoryItem item)
    {
        if (!item.isUsable) return;
        
        GameManager.UseItem(item);
        RefreshInventory(); // Обновляем список
    }
}

// Компонент элемента списка
public class InventorySlotComponent : WindowComponent
{
    [SerializeField] private ImageComponent itemIcon;
    [SerializeField] private TextComponent itemName;
    [SerializeField] private TextComponent itemCount;
    [SerializeField] private ButtonComponent useButton;

    public void SetItem(InventoryItem item)
    {
        itemIcon.SetSprite(item.icon);
        itemName.SetText(item.name);
        itemCount.SetText(item.count.ToString());
        useButton.SetInteractable(item.isUsable);
    }

    public void SetClickCallback(System.Action callback)
    {
        useButton.SetCallback(callback);
    }
}
```

**Продвинутые возможности ListComponent:**
- **Бесконечная прокрутка** - `ListEndlessComponentModule`
- **Группировка элементов** - `ListArrangementComponentModule`
- **Чекбоксы в списке** - `ListCheckboxGroupModule`
- **Swipe жесты** - `CircleSwipeComponentModule`

#### 🎛️ Другие компоненты

**InputFieldComponent** - поле ввода:
```csharp
public class PlayerNameInputComponent : InputFieldComponent
{
    protected override void OnValueChanged(string newValue)
    {
        // Валидация имени
        if (newValue.Length > 20)
        {
            SetText(newValue.Substring(0, 20));
        }
    }
}
```

**ProgressComponent** - полоса прогресса:
```csharp
public class HealthBarComponent : ProgressComponent
{
    public void SetHealth(float health, float maxHealth)
    {
        float percentage = health / maxHealth;
        SetValue(percentage);
        
        // Меняем цвет в зависимости от здоровья
        if (percentage < 0.3f)
            SetColor(Color.red);
        else if (percentage < 0.6f)
            SetColor(Color.yellow);
        else
            SetColor(Color.green);
    }
}
```

**DropdownComponent** - выпадающий список:
```csharp
public class LanguageDropdownComponent : DropdownComponent
{
    public override void OnInitialize()
    {
        var languages = new[] { "Русский", "English", "Deutsch" };
        SetOptions(languages);
        
        SetCallback((selectedIndex) => {
            ChangeLanguage(selectedIndex);
        });
    }
}
```

### Создание собственных компонентов

```csharp
// Базовый компонент
public class CustomSliderComponent : WindowComponent
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextComponent valueText;

    private System.Action<float> onValueChanged;

    public override void OnInitialize()
    {
        slider.onValueChanged.AddListener(OnSliderChanged);
    }

    public void SetValue(float value)
    {
        slider.value = value;
        UpdateValueText();
    }

    public void SetCallback(System.Action<float> callback)
    {
        onValueChanged = callback;
    }

    private void OnSliderChanged(float value)
    {
        UpdateValueText();
        onValueChanged?.Invoke(value);
    }

    private void UpdateValueText()
    {
        valueText.SetText($"{slider.value:F1}");
    }
}
```

### Модульная система компонентов

Компоненты можно расширять модулями:

```csharp
// Модуль для компонента
public class ButtonSoundModule : WindowComponentModule
{
    [SerializeField] private AudioClip clickSound;
    [SerializeField] private AudioClip hoverSound;

    public override void OnInitialize()
    {
        // Подписываемся на события кнопки
        var button = GetComponent<ButtonComponent>();
        button.OnClickEvent += PlayClickSound;
        button.OnHoverEvent += PlayHoverSound;
    }

    private void PlayClickSound()
    {
        AudioSource.PlayClipAtPoint(clickSound, Vector3.zero);
    }

    private void PlayHoverSound()
    {
        AudioSource.PlayClipAtPoint(hoverSound, Vector3.zero);
    }
}
```

## 🎬 Анимации - делаем красиво

### Зачем нужны анимации?

Анимации делают интерфейс живым и приятным. Экраны плавно появляются и исчезают, кнопки реагируют на нажатия, элементы двигаются естественно.

### Система анимационных параметров

UI.Windows использует **AnimationParameters** - готовые настройки анимаций:

```csharp
[System.Serializable]
public class MyComponentAnimation
{
    [AnimationParameters] // Этот атрибут создаёт красивый редактор
    public AnimationParameters showAnimation;
    
    [AnimationParameters]
    public AnimationParameters hideAnimation;
    
    [AnimationParameters]
    public AnimationParameters clickAnimation;
}
```

В инспекторе это выглядит как удобный редактор с настройками.

### Типы анимаций

#### 🌊 Альфа (прозрачность) анимации

```csharp
public class FadeButtonComponent : ButtonComponent
{
    public void FadeIn()
    {
        // Создаём параметры анимации прозрачности
        var fadeParams = new AlphaAnimationParameters()
        {
            from = 0f,           // Начальная прозрачность
            to = 1f,             // Конечная прозрачность
            duration = 0.5f,     // Длительность в секундах
            easing = Ease.OutCubic // Тип кривой анимации
        };
        
        // Запускаем анимацию
        RunAnimation(fadeParams);
    }

    public void FadeOut()
    {
        var fadeParams = new AlphaAnimationParameters()
        {
            from = 1f,
            to = 0f,
            duration = 0.3f,
            easing = Ease.InCubic
        };
        
        RunAnimation(fadeParams);
    }
}
```

#### 📐 Rect (размер и позиция) анимации

```csharp
public class SlideMenuComponent : WindowComponent
{
    public void SlideInFromLeft()
    {
        var rectParams = new RectAnimationParameters()
        {
            from = new Vector2(-300f, 0f), // Начальная позиция (слева от экрана)
            to = Vector2.zero,             // Конечная позиция (центр)
            duration = 0.4f,
            easing = Ease.OutBack          // Эффект "отскока"
        };
        
        RunAnimation(rectParams);
    }

    public void ScaleUp()
    {
        var scaleParams = new RectAnimationParameters()
        {
            animationType = RectAnimationType.Scale, // Анимируем масштаб
            from = Vector2.zero,                     // Начальный масштаб
            to = Vector2.one,                        // Конечный масштаб
            duration = 0.3f,
            easing = Ease.OutBounce
        };
        
        RunAnimation(scaleParams);
    }
}
```

### Состояния анимации

Каждый компонент имеет 4 состояния анимации:

- **Show** - анимация появления
- **Hide** - анимация исчезновения  
- **Reset** - сброс к начальному состоянию
- **Current** - текущее состояние

```csharp
public class AnimatedComponent : WindowComponent
{
    [SerializeField] private AnimationParameters showAnimation;
    [SerializeField] private AnimationParameters hideAnimation;

    public override void OnShowBegin()
    {
        // Автоматически запускается анимация появления
        RunAnimation(showAnimation);
    }

    public override void OnHideBegin()
    {
        // Автоматически запускается анимация исчезновения
        RunAnimation(hideAnimation);
    }
}
```

### Tweener - продвинутые анимации

Для более сложных анимаций используй встроенный **Tweener**:

```csharp
public class ComplexAnimationComponent : WindowComponent
{
    public void DoComplexAnimation()
    {
        // Анимация числа с колбэком
        Tweener.DoFloat(0f, 100f, 2f, (value) => {
            scoreText.text = $"Очки: {value:F0}";
        }).SetEase(Ease.OutCubic);

        // Анимация позиции
        var targetPos = new Vector3(100f, 50f, 0f);
        Tweener.DoVector3(transform.position, targetPos, 1f, (pos) => {
            transform.position = pos;
        }).SetEase(Ease.InOutSine);

        // Анимация цвета
        var targetColor = Color.red;
        Tweener.DoColor(Color.white, targetColor, 0.5f, (color) => {
            GetComponent<Image>().color = color;
        });

        // Последовательность анимаций
        Tweener.DoFloat(0f, 1f, 0.5f, (value) => {
            // Первая анимация
        }).SetOnComplete(() => {
            // После первой запускаем вторую
            Tweener.DoFloat(1f, 0f, 0.5f, (value) => {
                // Вторая анимация
            });
        });
    }
}
```

### Кривые анимации (Easing)

UI.Windows поддерживает множество типов кривых:

```csharp
// Базовые кривые
Ease.Linear        // Равномерно
Ease.InCubic       // Медленный старт
Ease.OutCubic      // Медленный финиш
Ease.InOutCubic    // Медленный старт и финиш

// Эффектные кривые
Ease.OutBounce     // Отскок в конце
Ease.OutBack       // Превышение и возврат
Ease.OutElastic    // Пружинный эффект

// И много других...
```

### Практические примеры анимаций

#### Анимированное появление экрана

```csharp
public class AnimatedScreen : WindowBase
{
    [SerializeField] private RectTransform contentPanel;

    public override void OnShowBegin()
    {
        // Экран появляется снизу
        contentPanel.anchoredPosition = new Vector2(0, -1000f);
        
        Tweener.DoVector2(
            new Vector2(0, -1000f), 
            Vector2.zero, 
            0.5f, 
            (pos) => contentPanel.anchoredPosition = pos
        ).SetEase(Ease.OutBack);
    }

    public override void OnHideBegin()
    {
        // Экран уходит вверх
        Tweener.DoVector2(
            contentPanel.anchoredPosition,
            new Vector2(0, 1000f),
            0.3f,
            (pos) => contentPanel.anchoredPosition = pos
        ).SetEase(Ease.InBack).SetOnComplete(() => {
            // Уведомляем систему что анимация закончена
            OnHideEnd();
        });
    }
}
```

#### Анимированная кнопка

```csharp
public class AnimatedButtonComponent : ButtonComponent
{
    private Vector3 originalScale;

    public override void OnInitialize()
    {
        originalScale = transform.localScale;
    }

    public override void OnClick()
    {
        // Анимация нажатия
        transform.localScale = originalScale * 0.9f;
        
        Tweener.DoVector3(
            originalScale * 0.9f,
            originalScale,
            0.1f,
            (scale) => transform.localScale = scale
        ).SetEase(Ease.OutBounce);

        base.OnClick();
    }

    protected override void OnHover()
    {
        // Анимация при наведении
        Tweener.DoVector3(
            transform.localScale,
            originalScale * 1.1f,
            0.2f,
            (scale) => transform.localScale = scale
        );
    }

    protected override void OnUnhover()
    {
        // Возврат к исходному размеру
        Tweener.DoVector3(
            transform.localScale,
            originalScale,
            0.2f,
            (scale) => transform.localScale = scale
        );
    }
}
```

#### Анимированная полоса здоровья

```csharp
public class AnimatedHealthBarComponent : WindowComponent
{
    [SerializeField] private Image healthFill;
    [SerializeField] private Image damageFill; // Красная полоса показывающая урон
    [SerializeField] private TextComponent healthText;

    public void SetHealth(float health, float maxHealth, bool animate = true)
    {
        float targetFill = health / maxHealth;
        
        if (animate)
        {
            // Анимируем заполнение
            Tweener.DoFloat(
                healthFill.fillAmount,
                targetFill,
                0.5f,
                (fill) => {
                    healthFill.fillAmount = fill;
                    UpdateHealthText(fill * maxHealth, maxHealth);
                }
            ).SetEase(Ease.OutCubic);

            // Показываем урон
            if (targetFill < healthFill.fillAmount)
            {
                ShowDamageEffect(healthFill.fillAmount, targetFill);
            }
        }
        else
        {
            healthFill.fillAmount = targetFill;
            UpdateHealthText(health, maxHealth);
        }
    }

    private void ShowDamageEffect(float fromFill, float toFill)
    {
        // Красная полоса показывает потерянное здоровье
        damageFill.fillAmount = fromFill;
        damageFill.color = new Color(1, 0, 0, 0.8f);

        // Плавно уменьшаем красную полосу
        Tweener.DoFloat(fromFill, toFill, 0.8f, (fill) => {
            damageFill.fillAmount = fill;
        }).SetDelay(0.3f).SetEase(Ease.OutCubic);

        // Плавно скрываем красную полосу
        Tweener.DoFloat(0.8f, 0f, 0.5f, (alpha) => {
            var color = damageFill.color;
            color.a = alpha;
            damageFill.color = color;
        }).SetDelay(0.8f);
    }

    private void UpdateHealthText(float health, float maxHealth)
    {
        healthText.SetText($"{health:F0}/{maxHealth:F0}");
    }
}
```

## 🧩 Встроенные модули (готовые решения)

UI.Windows поставляется с готовыми модулями для частых задач. Не нужно изобретать велосипед!

### 🖥️ Консоль отладки (Console System)

**Зачем нужна?** Для тестирования игры прямо во время выполнения. Можно вызывать команды, менять настройки, телепортироваться, спавнить объекты.

#### Базовое использование

```csharp
// Создай модуль консоли
public class GameConsoleModule : WindowSystemConsoleModule
{
    // Команда без параметров
    [RuntimeConsoleCommand("help")]
    public void ShowHelp()
    {
        Debug.Log("Доступные команды: spawn, teleport, heal, givegold");
    }

    // Команда с параметрами
    [RuntimeConsoleCommand("spawn")]
    public void SpawnEnemy(string enemyType, int count = 1)
    {
        Debug.Log($"Спавним {count} врагов типа {enemyType}");
        for (int i = 0; i < count; i++)
        {
            // GameManager.SpawnEnemy(enemyType);
        }
    }

    // Команда с разными типами параметров
    [RuntimeConsoleCommand("teleport")]
    public void TeleportPlayer(float x, float y, float z)
    {
        Debug.Log($"Телепортируем игрока в {x}, {y}, {z}");
        // Player.transform.position = new Vector3(x, y, z);
    }

    // Команда с bool параметром
    [RuntimeConsoleCommand("godmode")]
    public void ToggleGodMode(bool enabled)
    {
        Debug.Log($"Режим бога: {(enabled ? "включён" : "выключен")}");
        // Player.SetGodMode(enabled);
    }

    // Команда с enum параметром
    [RuntimeConsoleCommand("weather")]
    public void ChangeWeather(WeatherType weather)
    {
        Debug.Log($"Меняем погоду на {weather}");
        // WeatherManager.SetWeather(weather);
    }
}

public enum WeatherType
{
    Sunny, Rainy, Stormy, Snowy
}
```

#### Использование в игре

В консоли игрок может написать:
```
spawn orc 5          // Создать 5 орков
teleport 10 0 15     // Телепорт в координаты
godmode true         // Включить режим бога
weather rainy        // Включить дождь
```

#### Настройка консоли

```csharp
public class GameStarter : MonoBehaviour
{
    [SerializeField] private WindowSystemConsoleModule consoleModule;

    void Start()
    {
        // Добавляем модуль консоли в систему
        WindowSystem.GetModule<WindowSystemModules>().AddModule(consoleModule);
        
        // Настраиваем быстрые кнопки (Fast Links)
        consoleModule.AddFastLink("Полное здоровье", "heal 100");
        consoleModule.AddFastLink("1000 золота", "givegold 1000");
        consoleModule.AddFastLink("Убить всех врагов", "killall enemies");
    }
}
```

### 📚 Система обучения (Tutorial System)

**Зачем нужна?** Чтобы обучать игроков как пользоваться игрой. Показывать стрелочки, блокировать интерфейс, вести по шагам.

#### Создание обучения

```csharp
public class GameTutorialModule : TutorialModule
{
    protected override void OnInitialize()
    {
        // Создаём обучение для новых игроков
        CreateTutorial("first_time_tutorial", new TutorialStep[]
        {
            // Шаг 1: Приветствие
            new TutorialStep
            {
                id = "welcome",
                description = "Добро пожаловать в игру!",
                conditions = new ITutorialCondition[] 
                {
                    new HasKey("game_started") // Проверяем что игра началась
                },
                actions = new ITutorialAction[]
                {
                    new ShowScreen<TutorialWelcomeScreen>(), // Показать экран приветствия
                    new SetKey("tutorial_started", true)    // Отметить что обучение началось
                }
            },

            // Шаг 2: Показать как двигаться
            new TutorialStep
            {
                id = "movement",
                description = "Используйте WASD для движения",
                conditions = new ITutorialCondition[]
                {
                    new HasKey("tutorial_started")
                },
                actions = new ITutorialAction[]
                {
                    new ShowHideComponents(new[] { "MovementHint" }, true), // Показать подсказку
                    new LockElement("InventoryButton", true),              // Заблокировать кнопку инвентаря
                    new WaitForClick("MovementArea")                       // Ждать клик по области движения
                }
            },

            // Шаг 3: Показать инвентарь
            new TutorialStep
            {
                id = "inventory",
                description = "Нажмите на кнопку инвентаря",
                conditions = new ITutorialCondition[]
                {
                    new HasKey("movement_completed")
                },
                actions = new ITutorialAction[]
                {
                    new LockElement("InventoryButton", false),    // Разблокировать кнопку
                    new ShowArrow("InventoryButton"),             // Показать стрелку
                    new WaitForClick("InventoryButton"),          // Ждать клик по кнопке
                    new ShowScreen<InventoryScreen>(),            // Открыть инвентарь
                    new SetKey("tutorial_completed", true)       // Завершить обучение
                }
            }
        });
    }

    // Вызывается когда обучение завершено
    protected override void OnTutorialCompleted(string tutorialId)
    {
        if (tutorialId == "first_time_tutorial")
        {
            Debug.Log("Игрок прошёл базовое обучение!");
            // Можно дать награду, разблокировать контент и т.д.
        }
    }
}
```

#### Кастомные действия обучения

```csharp
// Кастомное действие - показать диалог с NPC
public class ShowNPCDialog : ITutorialAction
{
    public string npcId;
    public string dialogText;

    public void Execute()
    {
        var npc = GameObject.Find(npcId);
        if (npc != null)
        {
            var dialogSystem = npc.GetComponent<NPCDialogSystem>();
            dialogSystem.ShowDialog(dialogText);
        }
    }
}

// Кастомное условие - проверить уровень игрока
public class PlayerLevelCondition : ITutorialCondition
{
    public int requiredLevel;

    public bool IsTrue()
    {
        return GameManager.Player.Level >= requiredLevel;
    }
}
```

#### Интеграция с компонентами

```csharp
// Компонент кнопки, который учитывает обучение
public class TutorialAwareButtonComponent : ButtonComponent
{
    [SerializeField] private string tutorialTag = ""; // Тег для обучения

    protected override void OnInitialize()
    {
        base.OnInitialize();
        
        // Подписываемся на систему обучения
        var tutorialSystem = WindowSystem.GetModule<TutorialModule>();
        tutorialSystem.OnElementLocked += OnTutorialLock;
    }

    private void OnTutorialLock(string elementTag, bool isLocked)
    {
        if (elementTag == tutorialTag)
        {
            SetInteractable(!isLocked);
            
            // Показываем визуальный эффект блокировки
            if (isLocked)
            {
                GetComponent<CanvasGroup>().alpha = 0.5f;
            }
            else
            {
                GetComponent<CanvasGroup>().alpha = 1f;
            }
        }
    }
}
```

### 🎨 URP интеграция

**Зачем нужна?** Universal Render Pipeline требует особой настройки камер. Модуль автоматически всё настраивает.

```csharp
public class URPModule : WindowSystemModule
{
    public override void OnInitialize()
    {
        Debug.Log("Настраиваем URP для UI.Windows");
        
        // Автоматически настраиваем Camera Stack для URP
        SetupCameraStack();
        
        // Оптимизируем рендеринг для URP
        OptimizeURPRendering();
    }

    private void SetupCameraStack()
    {
        // Находим основную камеру
        var mainCamera = Camera.main;
        if (mainCamera != null)
        {
            var cameraData = mainCamera.GetUniversalAdditionalCameraData();
            if (cameraData != null)
            {
                // Настраиваем стек камер для UI
                // (детали реализации скрыты внутри модуля)
            }
        }
    }
}
```

### 🌐 Локализация

**Зачем нужна?** Поддержка разных языков в игре.

```csharp
// Компонент с локализованным текстом
public class LocalizedMenuComponent : TextComponent
{
    [SerializeField] private string localizationKey = "MENU_PLAY";

    protected override void OnInitialize()
    {
        base.OnInitialize();
        
        // Добавляем модуль локализации
        var locModule = AddModule<TextLocalizationComponentModule>();
        locModule.SetLocalizationKey(localizationKey);
        
        // Подписываемся на смену языка
        LocalizationSettings.SelectedLocaleChanged += OnLanguageChanged;
    }

    private void OnLanguageChanged(Locale newLocale)
    {
        // Текст автоматически обновится через модуль локализации
        Debug.Log($"Язык изменён на: {newLocale.Identifier.Code}");
    }
}
```

### 📦 Атласы спрайтов

**Зачем нужны?** Оптимизация - объединение множества маленьких картинок в одну большую.

```csharp
public class AtlasModule : WindowSystemModule
{
    [SerializeField] private SpriteAtlas uiAtlas;

    public override void OnInitialize()
    {
        // Регистрируем атлас в системе
        RegisterAtlas(uiAtlas);
    }

    // Загрузка спрайта из атласа
    public Sprite GetSpriteFromAtlas(string spriteName)
    {
        return uiAtlas.GetSprite(spriteName);
    }
}

// Использование в компонентах
public class IconComponent : ImageComponent
{
    public void SetIcon(string iconName)
    {
        var atlasModule = WindowSystem.GetModule<AtlasModule>();
        var sprite = atlasModule.GetSpriteFromAtlas(iconName);
        SetSprite(sprite);
    }
}
```

## 🛠️ Инструменты редактора

UI.Windows предоставляет мощные инструменты для работы в редакторе Unity.

### Мастер создания экранов

**Где найти:** Правой кнопкой в проекте → **Create → UI.Windows → Screen**

**Что делает:**
1. Создаёт скрипт экрана с правильным наследованием
2. Создаёт префаб макета с настроенным Canvas
3. Создаёт структуру папок для компонентов
4. Связывает всё вместе

**Пример созданной структуры:**
```
Screens/
├── MainMenu/
│   ├── MainMenuScreen.cs          // Скрипт экрана
│   ├── MainMenuLayout.prefab      // Префаб макета
│   └── Components/                // Папка для компонентов
│       ├── PlayButtonComponent.cs
│       └── SettingsButtonComponent.cs
```

### Валидация и проверки

UI.Windows автоматически проверяет твой проект и показывает ошибки:

#### Проверка ссылок

```csharp
// В инспекторе компонента ты увидишь предупреждения:
public class MyScreen : WindowBase
{
    [RequiredReference] // Этот атрибут покажет ошибку если ссылка пустая
    [SerializeField] private ButtonComponent playButton;
    
    [RequiredReference]
    [SerializeField] private WindowLayout layout;
}
```

#### Проверка ресурсов

Система автоматически проверяет:
- Все ли ссылки на компоненты заполнены
- Правильно ли настроены Addressable ресурсы
- Нет ли циклических зависимостей между экранами
- Корректно ли настроены анимации

### Кастомные Property Drawer'ы

UI.Windows предоставляет красивые редакторы для сложных типов:

#### AnimationParameters

```csharp
[System.Serializable]
public class MyAnimation
{
    [AnimationParameters] // Красивый редактор анимации
    public AnimationParameters fadeIn;
}
```

В инспекторе это выглядит как:
- Выпадающий список типов анимации
- Поля для настройки от/до
- Слайдер длительности
- Выбор кривой анимации
- Кнопка предварительного просмотра

#### LayoutSelector

```csharp
[System.Serializable]
public class ScreenSettings
{
    [LayoutSelector] // Выбор макета из списка
    public WindowLayout layout;
}
```

#### SearchTypePopup

```csharp
[System.Serializable]
public class ComponentReference
{
    [SearchTypePopup(typeof(WindowComponent))] // Поиск типов компонентов
    public string componentType;
}
```

### Инструменты отладки

#### Window System Inspector

Когда выбираешь WindowSystem в сцене, видишь:
- Список всех активных экранов
- Их состояния (Showing, Shown, Hiding, Hidden)
- Параметры каждого экрана
- Кнопки для принудительного показа/скрытия
- Статистику производительности

#### Component Inspector

Для каждого компонента показывается:
- Текущее состояние
- Список подключённых модулей
- Ссылки на связанные объекты
- Кнопки для тестирования анимаций

#### Performance Profiler

```csharp
// Включи профилирование производительности
WindowSystem.Settings.enablePerformanceLogging = true;

// В консоли Unity увидишь:
// [UI.Windows] Screen transition: MainMenu → GameScreen took 234ms
// [UI.Windows] Animation: FadeIn completed in 156ms
// [UI.Windows] Resource loading: PlayerIcon took 45ms
```

### Addressables интеграция

UI.Windows автоматически настраивает Addressables:

1. **Автоматическая маркировка** - экраны и ресурсы автоматически помечаются как Addressable
2. **Группировка** - ресурсы группируются по экранам
3. **Валидация** - проверка что все ссылки корректны
4. **Оптимизация** - анализ зависимостей и предложения по оптимизации

### Создание кастомных редакторов

Можешь создать свои инструменты:

```csharp
#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(MyCustomComponent))]
public class MyCustomComponentEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var component = (MyCustomComponent)target;
        
        EditorGUILayout.LabelField("Мой кастомный компонент", EditorStyles.boldLabel);
        
        // Кнопка для быстрой настройки
        if (GUILayout.Button("Быстрая настройка"))
        {
            component.SetupDefaults();
        }
        
        // Стандартный инспектор
        DrawDefaultInspector();
        
        // Кастомная валидация
        if (component.someField == null)
        {
            EditorGUILayout.HelpBox("Поле не заполнено!", MessageType.Warning);
        }
    }
}
#endif
```

## 💡 Примеры от простого к сложному

### 🚀 Пример 1: Простое главное меню

Создаём базовое главное меню с тремя кнопками.

#### Структура

```
MainMenu/
├── MainMenuScreen.cs
├── MainMenuLayout.prefab
└── Components/
    ├── PlayButtonComponent.cs
    ├── SettingsButtonComponent.cs
    └── ExitButtonComponent.cs
```

#### Код экрана

```csharp
using UnityEngine;
using UnityEngine.UI.Windows;

public class MainMenuScreen : WindowBase
{
    [SerializeField] private PlayButtonComponent playButton;
    [SerializeField] private SettingsButtonComponent settingsButton;
    [SerializeField] private ExitButtonComponent exitButton;

    public override void OnShowEnd()
    {
        // Настраиваем кнопки когда экран полностью показался
        SetupButtons();
        
        // Проигрываем фоновую музыку
        AudioManager.PlayMusic("MainMenuTheme");
    }

    private void SetupButtons()
    {
        // Кнопка играть
        playButton.Setup("ИГРАТЬ", () => {
            StartNewGame();
        });

        // Кнопка настройки
        settingsButton.Setup("НАСТРОЙКИ", () => {
            OpenSettings();
        });

        // Кнопка выход
        exitButton.Setup("ВЫХОД", () => {
            ExitGame();
        });
    }

    private void StartNewGame()
    {
        // Показываем экран загрузки
        WindowSystem.Show<LoadingScreen>();
        
        // Скрываем главное меню
        WindowSystem.Hide<MainMenuScreen>();
        
        // Начинаем загрузку игры
        GameManager.StartNewGame();
    }

    private void OpenSettings()
    {
        // Показываем настройки как оверлей (поверх главного меню)
        var parameters = new ScreenItem().SetAsOverlay(true);
        WindowSystem.Show<SettingsScreen>(parameters);
    }

    private void ExitGame()
    {
        // Показываем диалог подтверждения
        var confirmParams = new ConfirmDialogParameters
        {
            title = "Выход из игры",
            message = "Вы уверены что хотите выйти?",
            onConfirm = () => Application.Quit(),
            onCancel = () => Debug.Log("Отмена выхода")
        };

        var parameters = new ScreenItem().SetParameters(confirmParams);
        WindowSystem.Show<ConfirmDialogScreen>(parameters);
    }
}
```

#### Код компонента кнопки

```csharp
using UnityEngine;
using UnityEngine.UI.Windows.Components;

public class PlayButtonComponent : ButtonComponent
{
    [SerializeField] private TextComponent buttonText;
    private System.Action onClickCallback;

    public void Setup(string text, System.Action onClick)
    {
        buttonText.SetText(text);
        onClickCallback = onClick;
        
        // Настраиваем визуальные эффекты
        SetupVisualEffects();
    }

    public override void OnClick()
    {
        // Воспроизводим звук клика
        AudioManager.PlaySFX("ButtonClick");
        
        // Анимация нажатия
        PlayClickAnimation();
        
        // Вызываем колбэк
        onClickCallback?.Invoke();
    }

    private void SetupVisualEffects()
    {
        // Эффект при наведении
        SetHoverCallback(() => {
            transform.localScale = Vector3.one * 1.05f;
            AudioManager.PlaySFX("ButtonHover");
        });

        // Убираем эффект при уходе курсора
        SetUnhoverCallback(() => {
            transform.localScale = Vector3.one;
        });
    }

    private void PlayClickAnimation()
    {
        // Анимация "нажатия"
        transform.localScale = Vector3.one * 0.95f;
        
        Tweener.DoVector3(
            Vector3.one * 0.95f,
            Vector3.one,
            0.1f,
            (scale) => transform.localScale = scale
        ).SetEase(Ease.OutBounce);
    }
}
```

### 🎮 Пример 2: Игровой HUD с анимациями

Создаём интерфейс во время игры с полосами здоровья, очками, мини-картой.

#### Структура HUD

```csharp
public class GameHUDScreen : WindowBase
{
    [Header("Статистики игрока")]
    [SerializeField] private HealthBarComponent healthBar;
    [SerializeField] private ManaBarComponent manaBar;
    [SerializeField] private ScoreDisplayComponent scoreDisplay;
    [SerializeField] private LevelDisplayComponent levelDisplay;

    [Header("Интерфейс")]
    [SerializeField] private MinimapComponent minimap;
    [SerializeField] private InventoryQuickSlotsComponent quickSlots;
    [SerializeField] private ChatComponent chat;

    [Header("Кнопки")]
    [SerializeField] private ButtonComponent pauseButton;
    [SerializeField] private ButtonComponent inventoryButton;
    [SerializeField] private ButtonComponent settingsButton;

    private Player player;

    public override void OnShowBegin()
    {
        // Получаем ссылку на игрока
        player = GameManager.CurrentPlayer;
        
        // Подписываемся на события игрока
        SubscribeToPlayerEvents();
        
        // Инициализируем компоненты
        InitializeHUDComponents();
    }

    public override void OnHideBegin()
    {
        // Отписываемся от событий
        UnsubscribeFromPlayerEvents();
    }

    private void SubscribeToPlayerEvents()
    {
        if (player != null)
        {
            player.OnHealthChanged += UpdateHealth;
            player.OnManaChanged += UpdateMana;
            player.OnExperienceChanged += UpdateExperience;
            player.OnLevelUp += OnPlayerLevelUp;
            player.OnInventoryChanged += UpdateQuickSlots;
        }

        // Подписываемся на игровые события
        GameManager.OnScoreChanged += UpdateScore;
        GameManager.OnPlayerDied += OnPlayerDied;
        ChatSystem.OnMessageReceived += OnChatMessage;
    }

    private void InitializeHUDComponents()
    {
        // Настраиваем полосы здоровья и маны
        healthBar.Initialize(player.MaxHealth);
        manaBar.Initialize(player.MaxMana);
        
        // Настраиваем отображение уровня
        levelDisplay.SetLevel(player.Level);
        
        // Настраиваем мини-карту
        minimap.Initialize(player.transform);
        
        // Настраиваем быстрые слоты инвентаря
        quickSlots.Initialize(player.Inventory);
        
        // Настраиваем кнопки
        SetupButtons();
        
        // Обновляем все значения
        UpdateAllDisplays();
    }

    private void UpdateHealth(float newHealth, float maxHealth)
    {
        healthBar.SetValue(newHealth, maxHealth, animate: true);
        
        // Эффект при низком здоровье
        if (newHealth / maxHealth < 0.25f)
        {
            healthBar.StartLowHealthEffect();
        }
        else
        {
            healthBar.StopLowHealthEffect();
        }
    }

    private void OnPlayerLevelUp(int newLevel)
    {
        // Анимация повышения уровня
        levelDisplay.PlayLevelUpAnimation(newLevel);
        
        // Эффект частиц
        PlayLevelUpParticles();
        
        // Звук
        AudioManager.PlaySFX("LevelUp");
    }
}
```

#### Компонент полосы здоровья

```csharp
public class HealthBarComponent : WindowComponent
{
    [SerializeField] private Image healthFillImage;
    [SerializeField] private Image damageFillImage; // Показывает потерянное здоровье
    [SerializeField] private TextComponent healthText;
    [SerializeField] private GameObject lowHealthWarning;

    private float currentHealth;
    private float maxHealth;
    private Coroutine lowHealthEffectCoroutine;

    public void Initialize(float maxHP)
    {
        maxHealth = maxHP;
        currentHealth = maxHP;
        UpdateDisplay();
    }

    public void SetValue(float health, float maxHP, bool animate = false)
    {
        float previousHealth = currentHealth;
        currentHealth = health;
        maxHealth = maxHP;

        if (animate)
        {
            AnimateHealthChange(previousHealth, health);
        }
        else
        {
            UpdateDisplay();
        }
    }

    private void AnimateHealthChange(float fromHealth, float toHealth)
    {
        float fromFill = fromHealth / maxHealth;
        float toFill = toHealth / maxHealth;

        // Если получили урон - показываем красную полосу
        if (toHealth < fromHealth)
        {
            ShowDamageAnimation(fromFill, toFill);
        }

        // Анимируем основную полосу здоровья
        Tweener.DoFloat(fromFill, toFill, 0.5f, (fill) => {
            healthFillImage.fillAmount = fill;
            UpdateHealthText();
        }).SetEase(Ease.OutCubic);

        // Меняем цвет в зависимости от здоровья
        UpdateHealthColor(toFill);
    }

    private void ShowDamageAnimation(float fromFill, float toFill)
    {
        // Устанавливаем красную полосу на текущий уровень здоровья
        damageFillImage.fillAmount = fromFill;
        damageFillImage.color = Color.red;

        // Плавно уменьшаем красную полосу до нового уровня
        Tweener.DoFloat(fromFill, toFill, 0.8f, (fill) => {
            damageFillImage.fillAmount = fill;
        }).SetDelay(0.3f).SetEase(Ease.OutCubic);
    }

    private void UpdateHealthColor(float healthPercent)
    {
        Color targetColor;
        
        if (healthPercent > 0.6f)
            targetColor = Color.green;
        else if (healthPercent > 0.3f)
            targetColor = Color.yellow;
        else
            targetColor = Color.red;

        // Плавно меняем цвет
        Tweener.DoColor(healthFillImage.color, targetColor, 0.3f, (color) => {
            healthFillImage.color = color;
        });
    }

    public void StartLowHealthEffect()
    {
        if (lowHealthEffectCoroutine != null) return;
        
        lowHealthWarning.SetActive(true);
        lowHealthEffectCoroutine = StartCoroutine(LowHealthPulseEffect());
    }

    public void StopLowHealthEffect()
    {
        if (lowHealthEffectCoroutine != null)
        {
            StopCoroutine(lowHealthEffectCoroutine);
            lowHealthEffectCoroutine = null;
        }
        
        lowHealthWarning.SetActive(false);
    }

    private IEnumerator LowHealthPulseEffect()
    {
        while (true)
        {
            // Пульсация предупреждения
            Tweener.DoFloat(0f, 1f, 0.5f, (alpha) => {
                var color = lowHealthWarning.GetComponent<Image>().color;
                color.a = alpha;
                lowHealthWarning.GetComponent<Image>().color = color;
            });

            yield return new WaitForSeconds(0.5f);

            Tweener.DoFloat(1f, 0f, 0.5f, (alpha) => {
                var color = lowHealthWarning.GetComponent<Image>().color;
                color.a = alpha;
                lowHealthWarning.GetComponent<Image>().color = color;
            });

            yield return new WaitForSeconds(0.5f);
        }
    }

    private void UpdateDisplay()
    {
        healthFillImage.fillAmount = currentHealth / maxHealth;
        UpdateHealthText();
    }

    private void UpdateHealthText()
    {
        healthText.SetText($"{currentHealth:F0} / {maxHealth:F0}");
    }
}
```

### 📦 Пример 3: Сложный инвентарь с фильтрацией

Создаём продвинутый инвентарь с категориями, поиском, сортировкой.

#### Система предметов

```csharp
[System.Serializable]
public class InventoryItem
{
    public string id;
    public string name;
    public string description;
    public Sprite icon;
    public ItemType type;
    public ItemRarity rarity;
    public int count;
    public int maxStack;
    public bool isUsable;
    public bool isEquippable;
    public ItemStats stats;
}

public enum ItemType
{
    Weapon, Armor, Consumable, Material, Quest, Misc
}

public enum ItemRarity
{
    Common, Uncommon, Rare, Epic, Legendary
}

[System.Serializable]
public class ItemStats
{
    public int damage;
    public int defense;
    public int healthBonus;
    public int manaBonus;
    // и другие характеристики
}
```

#### Экран инвентаря

```csharp
public class InventoryScreen : WindowBase
{
    [Header("Основные компоненты")]
    [SerializeField] private InventoryGridComponent itemGrid;
    [SerializeField] private ItemDetailsPanelComponent detailsPanel;
    [SerializeField] private FilterPanelComponent filterPanel;
    [SerializeField] private SearchComponent searchComponent;

    [Header("Информация игрока")]
    [SerializeField] private TextComponent goldDisplay;
    [SerializeField] private TextComponent weightDisplay;

    [Header("Кнопки")]
    [SerializeField] private ButtonComponent closeButton;
    [SerializeField] private ButtonComponent sortButton;
    [SerializeField] private ButtonComponent useButton;
    [SerializeField] private ButtonComponent dropButton;

    private PlayerInventory inventory;
    private InventoryItem selectedItem;
    private List<InventoryItem> filteredItems;

    public override void OnShowBegin()
    {
        inventory = GameManager.CurrentPlayer.Inventory;
        
        // Загружаем данные инвентаря
        LoadInventoryData();
        
        // Настраиваем компоненты
        SetupComponents();
        
        // Обновляем отображение
        RefreshDisplay();
    }

    private void LoadInventoryData()
    {
        var allItems = inventory.GetAllItems();
        filteredItems = new List<InventoryItem>(allItems);
        
        // Обновляем информацию о игроке
        UpdatePlayerInfo();
    }

    private void SetupComponents()
    {
        // Настраиваем сетку предметов
        itemGrid.Setup(filteredItems);
        itemGrid.OnItemSelected += OnItemSelected;
        itemGrid.OnItemDoubleClicked += OnItemDoubleClicked;

        // Настраиваем фильтры
        filterPanel.OnFilterChanged += OnFilterChanged;
        filterPanel.SetAvailableTypes(GetAvailableItemTypes());

        // Настраиваем поиск
        searchComponent.OnSearchChanged += OnSearchChanged;

        // Настраиваем кнопки
        closeButton.SetCallback(() => WindowSystem.Hide<InventoryScreen>());
        sortButton.SetCallback(() => SortItems());
        useButton.SetCallback(() => UseSelectedItem());
        dropButton.SetCallback(() => DropSelectedItem());

        // Изначально кнопки действий отключены
        useButton.SetInteractable(false);
        dropButton.SetInteractable(false);
    }

    private void OnItemSelected(InventoryItem item)
    {
        selectedItem = item;
        
        // Показываем детали предмета
        detailsPanel.ShowItem(item);
        
        // Обновляем состояние кнопок
        UpdateActionButtons();
    }

    private void OnItemDoubleClicked(InventoryItem item)
    {
        // Двойной клик = использовать предмет
        if (item.isUsable)
        {
            UseItem(item);
        }
        else if (item.isEquippable)
        {
            EquipItem(item);
        }
    }

    private void OnFilterChanged(FilterSettings filters)
    {
        ApplyFilters(filters);
        RefreshItemGrid();
    }

    private void OnSearchChanged(string searchText)
    {
        ApplySearch(searchText);
        RefreshItemGrid();
    }

    private void ApplyFilters(FilterSettings filters)
    {
        filteredItems = inventory.GetAllItems().Where(item => {
            // Фильтр по типу
            if (filters.selectedTypes.Count > 0 && !filters.selectedTypes.Contains(item.type))
                return false;

            // Фильтр по редкости
            if (filters.minRarity != ItemRarity.Common && item.rarity < filters.minRarity)
                return false;

            // Фильтр "только экипируемые"
            if (filters.onlyEquippable && !item.isEquippable)
                return false;

            return true;
        }).ToList();
    }

    private void ApplySearch(string searchText)
    {
        if (string.IsNullOrEmpty(searchText))
        {
            // Если поиск пустой, показываем все отфильтрованные предметы
            return;
        }

        searchText = searchText.ToLower();
        filteredItems = filteredItems.Where(item => 
            item.name.ToLower().Contains(searchText) ||
            item.description.ToLower().Contains(searchText)
        ).ToList();
    }

    private void UseItem(InventoryItem item)
    {
        if (!item.isUsable) return;

        // Используем предмет
        bool wasUsed = inventory.UseItem(item);
        
        if (wasUsed)
        {
            // Воспроизводим эффект использования
            PlayItemUseEffect(item);
            
            // Обновляем отображение
            RefreshDisplay();
            
            // Если предмет закончился, снимаем выделение
            if (inventory.GetItemCount(item.id) == 0)
            {
                selectedItem = null;
                detailsPanel.Hide();
                UpdateActionButtons();
            }
        }
    }

    private void SortItems()
    {
        // Показываем меню сортировки
        var sortOptions = new[] {
            "По названию",
            "По типу", 
            "По редкости",
            "По количеству"
        };

        var parameters = new DropdownMenuParameters
        {
            title = "Сортировать по:",
            options = sortOptions,
            onSelected = (index) => ApplySort((SortType)index)
        };

        WindowSystem.Show<DropdownMenuScreen>(new ScreenItem().SetParameters(parameters));
    }

    private void PlayItemUseEffect(InventoryItem item)
    {
        // Частицы эффекта
        var effectPos = detailsPanel.transform.position;
        ParticleSystem.Play("ItemUseEffect", effectPos);
        
        // Звук
        AudioManager.PlaySFX($"Use{item.type}");
        
        // Анимация исчезновения количества
        var slot = itemGrid.GetSlotForItem(item);
        if (slot != null)
        {
            slot.PlayUseAnimation();
        }
    }
}
```

#### Компонент сетки предметов

```csharp
public class InventoryGridComponent : WindowComponent
{
    [SerializeField] private InventorySlotComponent slotPrefab;
    [SerializeField] private Transform gridContainer;
    [SerializeField] private ScrollRect scrollRect;

    private List<InventorySlotComponent> slots = new List<InventorySlotComponent>();
    private List<InventoryItem> items = new List<InventoryItem>();

    public System.Action<InventoryItem> OnItemSelected;
    public System.Action<InventoryItem> OnItemDoubleClicked;

    public void Setup(List<InventoryItem> inventoryItems)
    {
        items = inventoryItems;
        CreateSlots();
        RefreshSlots();
    }

    private void CreateSlots()
    {
        // Очищаем старые слоты
        foreach (var slot in slots)
        {
            if (slot != null) Destroy(slot.gameObject);
        }
        slots.Clear();

        // Создаём новые слоты
        for (int i = 0; i < items.Count; i++)
        {
            var slotGO = Instantiate(slotPrefab.gameObject, gridContainer);
            var slot = slotGO.GetComponent<InventorySlotComponent>();
            
            slot.Setup(items[i], i);
            slot.OnClicked += () => OnItemSelected?.Invoke(slot.Item);
            slot.OnDoubleClicked += () => OnItemDoubleClicked?.Invoke(slot.Item);
            
            slots.Add(slot);
        }
    }

    private void RefreshSlots()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (i < items.Count)
            {
                slots[i].SetItem(items[i]);
                slots[i].SetVisible(true);
            }
            else
            {
                slots[i].SetVisible(false);
            }
        }
    }

    public InventorySlotComponent GetSlotForItem(InventoryItem item)
    {
        return slots.FirstOrDefault(slot => slot.Item?.id == item.id);
    }
}
```

### 🎯 Пример 4: Система диалогов с NPC

Создаём продвинутую систему диалогов с ветвлением, условиями, эффектами.

#### Структура диалогов

```csharp
[System.Serializable]
public class DialogData
{
    public string id;
    public string npcName;
    public Sprite npcPortrait;
    public DialogNode[] nodes;
    public DialogCondition[] showConditions;
}

[System.Serializable]
public class DialogNode
{
    public string id;
    public string text;
    public DialogChoice[] choices;
    public DialogAction[] actions;
    public DialogCondition[] conditions;
    public bool isEndNode;
}

[System.Serializable]
public class DialogChoice
{
    public string text;
    public string targetNodeId;
    public DialogCondition[] conditions;
    public DialogAction[] actions;
}
```

#### Экран диалога

```csharp
public class DialogScreen : WindowBase
{
    [Header("UI Компоненты")]
    [SerializeField] private ImageComponent npcPortrait;
    [SerializeField] private TextComponent npcNameText;
    [SerializeField] private TextComponent dialogText;
    [SerializeField] private Transform choicesContainer;
    [SerializeField] private DialogChoiceComponent choicePrefab;

    [Header("Эффекты")]
    [SerializeField] private AnimationParameters textTypewriterEffect;
    [SerializeField] private AudioClip textTypeSound;

    private DialogData currentDialog;
    private DialogNode currentNode;
    private List<DialogChoiceComponent> choiceButtons = new List<DialogChoiceComponent>();
    private Coroutine typewriterCoroutine;

    public override void OnParametersPass(ScreenItem item)
    {
        var dialogParams = item.GetParameter<DialogParameters>();
        currentDialog = dialogParams.dialogData;
        
        SetupDialog();
    }

    private void SetupDialog()
    {
        // Настраиваем портрет и имя NPC
        npcPortrait.SetSprite(currentDialog.npcPortrait);
        npcNameText.SetText(currentDialog.npcName);

        // Находим стартовую ноду
        currentNode = FindStartNode();
        
        // Показываем первую реплику
        ShowCurrentNode();
    }

    private DialogNode FindStartNode()
    {
        // Ищем ноду с id "start" или первую доступную
        var startNode = currentDialog.nodes.FirstOrDefault(n => n.id == "start");
        if (startNode != null && CheckNodeConditions(startNode))
            return startNode;

        // Если стартовой ноды нет, берём первую подходящую
        foreach (var node in currentDialog.nodes)
        {
            if (CheckNodeConditions(node))
                return node;
        }

        Debug.LogError($"Не найдена доступная стартовая нода для диалога {currentDialog.id}");
        return currentDialog.nodes[0]; // В крайнем случае берём первую
    }

    private void ShowCurrentNode()
    {
        if (currentNode == null) return;

        // Выполняем действия ноды
        ExecuteNodeActions(currentNode.actions);

        // Показываем текст с эффектом печатной машинки
        ShowDialogText(currentNode.text);

        // Создаём варианты ответов
        CreateChoiceButtons();
    }

    private void ShowDialogText(string text)
    {
        // Останавливаем предыдущую анимацию текста
        if (typewriterCoroutine != null)
        {
            StopCoroutine(typewriterCoroutine);
        }

        // Запускаем эффект печатной машинки
        typewriterCoroutine = StartCoroutine(TypewriterEffect(text));
    }

    private IEnumerator TypewriterEffect(string fullText)
    {
        dialogText.SetText("");
        
        for (int i = 0; i <= fullText.Length; i++)
        {
            dialogText.SetText(fullText.Substring(0, i));
            
            // Звук печати (не на каждую букву, чтобы не раздражало)
            if (i % 3 == 0 && textTypeSound != null)
            {
                AudioSource.PlayClipAtPoint(textTypeSound, Vector3.zero, 0.3f);
            }
            
            yield return new WaitForSeconds(0.03f);
        }
        
        typewriterCoroutine = null;
        
        // Когда текст полностью показан, активируем кнопки выборов
        SetChoiceButtonsInteractable(true);
    }

    private void CreateChoiceButtons()
    {
        // Очищаем старые кнопки
        ClearChoiceButtons();

        // Если это конечная нода, показываем только кнопку "Закрыть"
        if (currentNode.isEndNode)
        {
            CreateEndDialogButton();
            return;
        }

        // Создаём кнопки для каждого доступного выбора
        foreach (var choice in currentNode.choices)
        {
            if (CheckChoiceConditions(choice))
            {
                CreateChoiceButton(choice);
            }
        }

        // Если нет доступных выборов, создаём кнопку "Продолжить"
        if (choiceButtons.Count == 0)
        {
            CreateContinueButton();
        }

        // Изначально кнопки неактивны (пока не закончится печать текста)
        SetChoiceButtonsInteractable(false);
    }

    private void CreateChoiceButton(DialogChoice choice)
    {
        var choiceGO = Instantiate(choicePrefab.gameObject, choicesContainer);
        var choiceComponent = choiceGO.GetComponent<DialogChoiceComponent>();
        
        choiceComponent.Setup(choice.text, () => OnChoiceSelected(choice));
        choiceButtons.Add(choiceComponent);
    }

    private void CreateEndDialogButton()
    {
        var choiceGO = Instantiate(choicePrefab.gameObject, choicesContainer);
        var choiceComponent = choiceGO.GetComponent<DialogChoiceComponent>();
        
        choiceComponent.Setup("Закончить разговор", () => {
            EndDialog();
        });
        
        choiceButtons.Add(choiceComponent);
    }

    private void OnChoiceSelected(DialogChoice choice)
    {
        // Выполняем действия выбора
        ExecuteChoiceActions(choice.actions);

        // Переходим к следующей ноде
        var nextNode = currentDialog.nodes.FirstOrDefault(n => n.id == choice.targetNodeId);
        if (nextNode != null)
        {
            currentNode = nextNode;
            ShowCurrentNode();
        }
        else
        {
            Debug.LogError($"Не найдена нода с id: {choice.targetNodeId}");
            EndDialog();
        }
    }

    private bool CheckNodeConditions(DialogNode node)
    {
        if (node.conditions == null || node.conditions.Length == 0)
            return true;

        foreach (var condition in node.conditions)
        {
            if (!EvaluateCondition(condition))
                return false;
        }

        return true;
    }

    private bool CheckChoiceConditions(DialogChoice choice)
    {
        if (choice.conditions == null || choice.conditions.Length == 0)
            return true;

        foreach (var condition in choice.conditions)
        {
            if (!EvaluateCondition(condition))
                return false;
        }

        return true;
    }

    private bool EvaluateCondition(DialogCondition condition)
    {
        // Здесь проверяем различные условия
        switch (condition.type)
        {
            case DialogConditionType.HasItem:
                return GameManager.CurrentPlayer.Inventory.HasItem(condition.stringValue, condition.intValue);
            
            case DialogConditionType.PlayerLevel:
                return GameManager.CurrentPlayer.Level >= condition.intValue;
            
            case DialogConditionType.QuestCompleted:
                return QuestManager.IsQuestCompleted(condition.stringValue);
            
            case DialogConditionType.Flag:
                return GameDataManager.GetFlag(condition.stringValue) == condition.boolValue;
            
            default:
                return true;
        }
    }

    private void ExecuteNodeActions(DialogAction[] actions)
    {
        if (actions == null) return;

        foreach (var action in actions)
        {
            ExecuteAction(action);
        }
    }

    private void ExecuteAction(DialogAction action)
    {
        switch (action.type)
        {
            case DialogActionType.GiveItem:
                GameManager.CurrentPlayer.Inventory.AddItem(action.stringValue, action.intValue);
                ShowNotification($"Получен предмет: {action.stringValue} x{action.intValue}");
                break;
            
            case DialogActionType.TakeItem:
                GameManager.CurrentPlayer.Inventory.RemoveItem(action.stringValue, action.intValue);
                break;
            
            case DialogActionType.GiveExperience:
                GameManager.CurrentPlayer.AddExperience(action.intValue);
                ShowNotification($"Получен опыт: {action.intValue}");
                break;
            
            case DialogActionType.StartQuest:
                QuestManager.StartQuest(action.stringValue);
                ShowNotification($"Получен квест: {QuestManager.GetQuest(action.stringValue).name}");
                break;
            
            case DialogActionType.SetFlag:
                GameDataManager.SetFlag(action.stringValue, action.boolValue);
                break;
        }
    }

    private void ShowNotification(string message)
    {
        // Показываем всплывающее уведомление
        var notificationParams = new NotificationParameters
        {
            message = message,
            duration = 3f,
            type = NotificationType.Info
        };

        WindowSystem.Show<NotificationScreen>(new ScreenItem().SetParameters(notificationParams));
    }

    private void EndDialog()
    {
        WindowSystem.Hide<DialogScreen>();
        
        // Возвращаем управление игроку
        GameManager.SetPlayerControlEnabled(true);
    }
}
```

## 🆘 Решение проблем

### Часто встречающиеся ошибки

#### ❌ "WindowSystem not found"

**Проблема:** В сцене нет объекта WindowSystem.

**Решение:**
1. Добавь в сцену объект с компонентом **Window System**
2. Или создай через меню: **GameObject → UI → Window System**

#### ❌ "Screen X is not registered"

**Проблема:** Экран не зарегистрирован в системе.

**Решение:**
```csharp
// Убедись что класс экрана наследуется от WindowBase
public class MyScreen : WindowBase // ← Обязательно наследование
{
    // код экрана
}
```

#### ❌ "Layout not found for screen"

**Проблема:** У экрана нет привязанного макета.

**Решение:**
1. Создай префаб макета с компонентом **WindowLayout**
2. В настройках экрана укажи ссылку на макет
3. Или используй мастер создания экранов

#### ❌ "Component reference is null"

**Проблема:** Ссылка на компонент не назначена.

**Решение:**
```csharp
public class MyScreen : WindowBase
{
    [RequiredReference] // Этот атрибут покажет ошибку в инспекторе
    [SerializeField] private ButtonComponent myButton;
}
```

### Проблемы с производительностью

#### 🐌 Медленные переходы между экранами

**Причины:**
- Слишком сложные анимации
- Много объектов в сцене
- Неоптимизированные ресурсы

**Решения:**
1. Упрости анимации переходов
2. Используй объектные пулы
3. Оптимизируй спрайты и текстуры
4. Включи профилирование:

```csharp
// Включи детальное логирование
WindowSystem.Settings.enablePerformanceLogging = true;
WindowSystem.Settings.enableDetailedLogging = true;
```

#### 🐌 Медленная прокрутка списков

**Причины:**
- Слишком много элементов создаётся сразу
- Сложная логика в OnDataBind

**Решения:**
1. Используй виртуализацию списков:

```csharp
public class OptimizedListComponent : ListComponent<MyItem>
{
    [SerializeField] private bool useVirtualization = true;
    [SerializeField] private int maxVisibleItems = 20;

    protected override void OnDataBind(MyItem item, int index)
    {
        // Минимизируй логику здесь
        var slot = GetComponentAtIndex<MySlotComponent>(index);
        slot.SetData(item); // Простое присвоение данных
    }
}
```

#### 🐌 Утечки памяти

**Причины:**
- Не освобождаются ресурсы при закрытии экранов
- Не отписываются от событий

**Решения:**
1. Правильно освобождай ресурсы:

```csharp
public class MyScreen : WindowBase
{
    public override void OnHideEnd()
    {
        // Отписываемся от всех событий
        GameManager.OnScoreChanged -= UpdateScore;
        Player.OnHealthChanged -= UpdateHealth;
        
        // Освобождаем ресурсы
        if (loadedTexture != null)
        {
            Resources.UnloadAsset(loadedTexture);
            loadedTexture = null;
        }
    }
}
```

### Проблемы с анимациями

#### 🎬 Анимации не воспроизводятся

**Проблема:** AnimationParameters настроены неправильно.

**Решение:**
1. Проверь что duration > 0
2. Убедись что from и to значения разные
3. Проверь что компонент активен:

```csharp
public override void OnShowBegin()
{
    // Убедись что объект активен перед анимацией
    if (!gameObject.activeInHierarchy)
    {
        gameObject.SetActive(true);
    }
    
    RunAnimation(showAnimation);
}
```

#### 🎬 Анимации тормозят

**Причины:**
- Слишком много анимаций одновременно
- Сложные кривые анимации

**Решения:**
1. Ограничь количество одновременных анимаций
2. Используй простые кривые (Linear, OutCubic)
3. Отключи анимации на слабых устройствах:

```csharp
public class AnimationSettings
{
    public static bool EnableAnimations => SystemInfo.processorCount > 2;
    
    public static void PlayAnimation(AnimationParameters parameters)
    {
        if (EnableAnimations)
        {
            // Полная анимация
            RunAnimation(parameters);
        }
        else
        {
            // Мгновенное переключение
            SetAnimationState(parameters.targetState);
        }
    }
}
```

### Проблемы с локализацией

#### 🌐 Текст не переключается при смене языка

**Проблема:** Компонент текста не подписан на смену языка.

**Решение:**
```csharp
public class LocalizedTextComponent : TextComponent
{
    [SerializeField] private string localizationKey;

    protected override void OnInitialize()
    {
        base.OnInitialize();
        
        // Добавляем модуль локализации
        var locModule = AddModule<TextLocalizationComponentModule>();
        locModule.SetLocalizationKey(localizationKey);
    }
}
```

### Отладка и диагностика

#### 🔍 Включение детального логирования

```csharp
void Start()
{
    // Включи все виды логирования
    WindowSystem.Settings.enablePerformanceLogging = true;
    WindowSystem.Settings.enableDetailedLogging = true;
    WindowSystem.Settings.enableAnimationLogging = true;
    WindowSystem.Settings.enableResourceLogging = true;
}
```

#### 🔍 Инструменты отладки в редакторе

1. **Window System Inspector** - показывает состояние всех экранов
2. **Component Inspector** - детали каждого компонента
3. **Performance Monitor** - статистика производительности
4. **Resource Monitor** - использование памяти

#### 🔍 Console команды для отладки

```csharp
[RuntimeConsoleCommand("ui_show")]
public void ShowScreen(string screenName)
{
    // Показать экран по имени
}

[RuntimeConsoleCommand("ui_hide")]
public void HideScreen(string screenName)
{
    // Скрыть экран по имени
}

[RuntimeConsoleCommand("ui_state")]
public void ShowUIState()
{
    // Показать состояние всех экранов
}

[RuntimeConsoleCommand("ui_performance")]
public void ShowPerformanceStats()
{
    // Показать статистику производительности
}
```

---

## 🎉 Заключение

**Поздравляю!** Теперь ты знаешь UI.Windows от А до Я. Этот фреймворк превратит создание интерфейсов из мучения в удовольствие.

### 🚀 Что дальше?

1. **Начни с простого** - создай базовое главное меню
2. **Изучи примеры** - разбери готовые компоненты  
3. **Экспериментируй** - пробуй разные анимации и эффекты
4. **Создавай свои модули** - расширяй функциональность под свои нужды

### 💡 Помни главные принципы:

- **Screen** = страница интерфейса
- **Layout** = разметка страницы  
- **Component** = элементы на странице
- **Module** = дополнительная функциональность

### 📞 Нужна помощь?

- 📧 **Email**: chrome.alex@gmail.com
- 🐛 **Баги**: [GitHub Issues](https://github.com/chromealex/UI.Windows-submodule/issues)
- 💬 **Обсуждения**: [GitHub Discussions](https://github.com/chromealex/UI.Windows-submodule/discussions)

---

**Удачи в создании крутых интерфейсов! 🎮✨**