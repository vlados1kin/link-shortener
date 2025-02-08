# Сайт с функцией сокращения ссылок URL
## Функции
- Просмотр статистики для ссылок: дата создания и количество переходов по коротким ссылкам
- Создание сокращенных ссылок
- Переход по сокращенным ссылкам
- Возможность редактирования и удаления ссылок
## Что сделать, чтобы запустить?
### **1. Клонировать этот репозиторий**
```shell
git clone https://github.com/vlados1kin/link-shortener
```
### **2. Перейти в директорию**
```shell
cd link-shortener
```
### **3. Поднять с Docker-контейнеры**
```shell
docker-compose up --build -d
```
Приложение будет доступно по адресу: [http://localhost:8080](http://localhost:8080)<br>
Главная страница с ссылками: [http://localhost:8080/index.html](http://localhost:8080/index.html)<br>
Страница для создания / редактирования: [http://localhost:8080/edit.html](http://localhost:8080/edit.html)<br>
Документация Swagger для API: [http://localhost:8080/swagger/v1/swagger.json](http://localhost:8080/swagger/v1/swagger.json)<br>
UI для документации Swagger: [http://localhost:8080/swagger/index.html](http://localhost:8080/swagger/index.html)

## Конечные точки API
| Метод  | Путь                  | Тело запроса                                   | Описание                          |
|--------|-----------------------|------------------------------------------------|-----------------------------------|
| POST   | /shortener            | ```{ "longUrl": "https://example.com" }```     | Создание<br/>короткой ссылки      |
| GET    | /shortener/{shortUrl} |                                                | Переход<br/>по короткому URL      |
| DELETE | /shortener/urls/{id}  |                                                | Удаление ссылки по id             |
| PUT    | /shortener/urls/{id}  | ```{ "longUrl": "https://new-example.com" }``` | Изменение ссылки по id            |
| GET    | /shortener/urls/{id}  |                                                | Получение ссылки по id            |
| GET    | /shortener/urls       |                                                | Получение всех сокращенных ссылок |
