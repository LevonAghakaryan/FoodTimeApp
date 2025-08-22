>>> - - -
>>>  🇬🇧 English

FoodTime - Online Food Store
A simple online food store web application developed with ASP.NET Core MVC. The project demonstrates a clean, layered architecture for building maintainable and scalable web applications.

✨ Key Features

- User Management: Registration and login system.
- Product Catalog: View the list of available products.
- Shopping Cart: Add products to a session-based cart.
- Admin Tools: Create and delete products.

🏛️ Architecture
>>>The project is divided into 4 main layers:

  1->FoodTime.Domain

  - The core of the application, containing Entities (Product, User), ViewModels, and Enums. This layer has no dependencies on other layers.

  2->FoodTime.DAL (Data Access Layer)

  - Responsible for direct interaction with the database.
  - Implements the Repository Pattern to abstract database logic.
  - Uses Entity Framework Core as the ORM.

  3->FoodTime.Service

  - The business logic layer. It contains the core operations (e.g., user registration, product purchase).
  - This layer connects the Presentation Layer (Controllers) with the DAL.

  4->FoodTime (Presentation Layer)

  - The main ASP.NET Core MVC project, which includes Controllers, Views, and other web-related files (wwwroot, Program.cs).


>>> - - -
>>>  🇦🇲 Հայերեն

  FoodTime - Սննդի առցանց խանութ
    Սննդի առցանց խանութի պարզ վեբ հավելված՝ մշակված ASP.NET Core MVC-ով։
    Նախագիծը ցուցադրում է մաքուր, բազմաշերտ ճարտարապետություն՝ սպասարկվող
    և ընդլայնվող վեբ հավելվածներ ստեղծելու համար։

✨ Հիմնական հնարավորություններ

  - Օգտատերերի կառավարում՝ գրանցում և մուտք համակարգ։
  - Ապրանքների կատալոգ՝ ապրանքների ցանկի դիտում։
  - Գնումների զամբյուղ՝ ապրանքների ավելացում զամբյուղ Session-ի միջոցով։
  - Ադմինիստրատիվ գործիքներ՝ ապրանքների ստեղծում և ջնջում։

🏛️ Ճարտարապետություն
  >>> Նախագիծը բաժանված է 4 հիմնական շերտերի․

  1->FoodTime.Domain

  - Հավելվածի հիմքը, որը պարունակում է Entity մոդելները (Product, User),
  - ViewModel-ները և Enum-ները։ Այս շերտը կախվածություն չունի մյուսներից։

  2->FoodTime.DAL (Data Access Layer)

  - Տվյալների հասանելիության շերտն է։ Պատասխանատու է տվյալների բազայի հետ ուղիղ աշխատանքի համար։
  - Կիրառում է Repository Pattern-ը՝ տրամաբանությունը տվյալների բազայից մեկուսացնելու համար։
  - Օգտագործում է Entity Framework Core-ը։

  3->FoodTime.Service

  - Բիզնես տրամաբանության շերտն է։ Այստեղ են գտնվում հիմնական գործողությունները (օրինակ՝ օգտատիրոջ գրանցում, ապրանքի գնում)։
  - Այս շերտը կապում է Presentation շերտը (Controller-ները) DAL-ի հետ։

  4->FoodTime (Presentation Layer)

  - ASP.NET Core MVC նախագիծն է, որը պարունակում է Controller-ները, View-երը և վեբին առնչվող մնացած ֆայլերը (wwwroot, Program.cs)։


>>> - - -
>>> 🇷🇺 Русский

FoodTime - Продуктовый Интернет-магазин
Простое веб-приложение для продуктового интернет-магазина, разработанное на ASP.NET Core MVC. Проект демонстрирует чистую, многоуровневую архитектуру для создания поддерживаемых и масштабируемых веб-приложений.

✨ Основные возможности
  - Управление пользователями: Система регистрации и входа.
  - Каталог товаров: Просмотр списка доступных товаров.
  - Корзина покупок: Добавление товаров в корзину на основе сессий.
  - Инструменты администратора: Создание и удаление товаров.

🏛️ Архитектура
>>>Проект разделен на 4 основных слоя:

  1->FoodTime.Domain
  
  - Ядро приложения, содержащее сущности (Product, User), ViewModel и Enum. Этот слой не имеет зависимостей от других слоев.

  2->FoodTime.DAL (Data Access Layer)
  
  - Слой доступа к данным. Отвечает за прямое взаимодействие с базой данных.  
  - Реализует паттерн Repository для изоляции логики работы с БД.  
  - Использует Entity Framework Core в качестве ORM.

  3->FoodTime.Service
  
  - Слой бизнес-логики. Здесь содержатся основные операции (например, регистрация пользователя, покупка товара).  
  - Этот слой связывает слой представления (контроллеры) с DAL.
    
  4->FoodTime (Presentation Layer)
  
  - Основной проект ASP.NET Core MVC, включающий контроллеры, представления и другие файлы, связанные с вебом (wwwroot, Program.cs).
