Это приложение представляет собой десктоп-клиент для интернет-магазина

Для полной демонстрации необходимо скачать и запустить docker image, который содержит web-часть проекта:
 - Web-реализацию интернет-магазина
 - Реализацию API для данного клиента

## Чтобы скачать docker image, выполните команду
``` bash 
docker pull slacklengo/zend_internet_shop_web
```

Контейнер содержит необходимую среду для работы Web-части проекта

Для запуска контейнера используйте команду
``` bash
docker run -it -p 5556:80 slacklengo/zend_internet_shop_web
```
Если при запуске контейнера вы меняете внешний порт (5556 по-умолчанию), то следует указать новый порт в файлах конфигурации клиента и web-части проекта:
 - В клиенте по пути client_root\wfxmlrpc\bin\Debug в файле Ini.ini укажите в параметре URL адрес проекта (по умолчанию указан локальный адрес виртуальной машины, на которой собирался контейнер с портом 5556)
 - В Web-части проекта, в контейнере по пути /var/www/zendapp/module/Application/config/config.php укажите переменную $domain, так же, как для клиента

После запуска контейнера запустите apache2 и mysql в контейнере следующими командами
``` bash
service apache2 start
./etc/init.d/mysql start
```
Теперь по адресу localhost:5556 из браузера должна быть доступна Web-реализация проекта "Интернет-магазин" (или, вместо localhost, локальный адрес машины с docker-контейнером)

Также в контейнере установлен phpmyadmin (доступ localhost:5556/phpmyadmin), логин "root", пароль "pika"

## Краткое описание web-реализации
Демонстрационный пользователь: логин "user", пароль "123"

Администратор: логин "admin", пароль "pika"

В Web-приложении реализованы:
 - Каталог товаров (localhost:5556/application/all-goods)
 - Отдельные страницы для каждого товара (localhost:5556/application/good-page/10, где 10 - id товара)
 - Регистрация (localhost:5556/application/reg)
 - Форма входа (localhost:5556/application/login)
 - Покупательская корзина (localhost:5556/application/shopping-cart)
 - Личный кабинет с просмотром истории транзакций пользователя (localhost:5556/application/dashboard)
 - Личный кабинет для администратора (localhost:5556/application/dashboard-admin) с функциями добавления товаров, просмотра популярного товара, объёма выручки, просмотра списка пользователей
 - Покупка товаров совершется AJAX скриптом
 - API для взаимодействия с интернет-магазином (класс, реализующий методы API /var/www/zendapp/module/Application/src/Controller/Greeter.php)
 - Точки входа для одного из трех протоколов XML-RPC, SOAP, REST (localhost:5556/xmlrpcapi/endpoint, localhost:5556/soapapi/endpoint, localhost:5556/restapi/rest, соответственно)
 
 ## Краткое описание клиентского desktop-приложения
  - Приложение взаимодействует по одному из трех протоколов обмена сообщениями/вызова удаленных процедур с API интернет-магазина (XML-RPC, SOAP, REST)
  - Все запросы к серверу и отправка ответов от него происходят с помощью JSON, передаваемого по одному из трех протоколов
