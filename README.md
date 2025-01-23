# Steam Badge Price Parser

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

🌐 English version
[![English](https://img.shields.io/badge/lang-English-blue)](README.en.md)
---

Приложение для Windows, которое помогает анализировать актуальные цены Steam-значков в вашей локальной валюте через прямое взаимодействие с торговой площадкой Steam.

## 🚀 Зачем это нужно?

Сервис [SteamCardExchange](https://www.steamcardexchange.net/) показывает цены значков только в долларах (USD), но реальная стоимость в других валютах (например, RUB, EUR, UAH) может значительно отличаться из-за:
- Динамики курсов валют
- Региональных цен Steam
- Рыночного спроса

**Пример:** Два значка с ценой 0.3$ на SteamCardExchange, на Торговой площадке Steam могут стоить:
- 18 ₽ (0.18$) 
- 38 ₽ (0.38$) 

Это приложение парсит цены **напрямую через ваш Steam-аккаунт**, учитывая вашу локальную валюту для точных расчетов.

## 📸 Скриншоты

| ![Main Interface](screenshot1.png) | ![Settings Menu](screenshot2.png) |
|:--:|:--:|
| *Главный экран* | *Настройки* |

## ✨ Особенности

- Автоматизированный парсинг через Selenium и Chrome
- Требуется авторизация в Steam для корректного отображения цен
- Фильтрация и сортировка игр:
  - Выбор количества отображаемых игр
  - Сортировка по стоимости значков
- Пошаговый парсинг:
  1. Получение списка игр с SteamCardExchange
  2. Поочередный анализ цен карточек через Steam Community Market
- Скорость обработки: ~1 секунда на 1 значок

## 🔒 Безопасность

**Важно:** Приложение **не взаимодействует с вашим аккаунтом Steam** за пределами авторизации через браузер. Оно не имеет доступа к вашим личным данным, инвентарю, кошельку или другим аккаунт-специфичным данным.  
- Авторизация происходит через стандартный интерфейс Steam в браузере.
- Приложение не сохраняет логины, пароли или cookies.
- Весь процесс парсинга происходит в браузере, а программа лишь обрабатывает публично доступные данные с торговой площадки Steam.
- В целях дополнительной безопасности можно использовать пустой аккаунт, на котором указана нужная вам валюта.
- Все функции парсера находятся в файле [Parser.cs](SteamBadgePriceParser/Parser.cs).

## ⚙️ Установка и требования

1. **Требования:**
   - Windows 7+
   - [.NET Framework 8.0](https://dotnet.microsoft.com/download/dotnet-framework) или новее
   - Google Chrome (последняя версия)
   - Установленный [ChromeDriver](https://chromedriver.chromium.org/) (совместимый с вашей версией Chrome)

2. **Установка:**
   - Скачайте последний релиз из раздела [Releases](https://github.com/Azy-s/SteamBadgePriceParser/releases)
   - Распакуйте архив
   - Убедитесь, что ChromeDriver находится в папке с приложением или прописан в PATH

## 🖥 Использование

1. Запустите приложение.
2. При первом запуске:
   - Авторизуйтесь в Steam через открывшееся окно Chrome.
   - Перейдите на [страницу цен значков](https://www.steamcardexchange.net/index.php?badgeprices) и настройте фильтры (Количество игр и сортировку по цене).
3. В приложении:
   - Нажмите **«Парсить игры»** для загрузки списка.
   - Выберите нужные игры, затем **ПКМ** и **[Проверить цену]**.
   - Либо нажмите **«Парсить цены»** для анализа стоимости всех игр в списке.

## ⚠️ Ограничения

- Парсинг зависит от скорости работы Steam Community Market.
- Для работы требуется стабильное интернет-соединение.
- Слишком большое количество запросов может привести к временному ограничению доступа к торговой площадке (Это не бан).

## 📄 Лицензия

MIT License. Подробнее в файле [LICENSE](LICENSE).

---

**Важно:** Это неофициальный инструмент. Используйте на свой риск. Разработчик не связан с Valve или SteamCardExchange.
