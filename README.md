# EducationalPractice
## Зеленцов Денис и Кузнецова Олеся 43П
 # День 1 Импорт базы данных 
Для того, чтобы импортировать данные в базу данных необходимо их привести к третьей нормальной форме. Для этого при помощи некоторых операций Excel данные приводятся к одному виду, выносятся повторяющиеся данные, а также исправляются синтаксические ошибки.
После всех операций два документа с пользователями и сервисами выглядят следующим образом.

Таблица пользователей

 ![image](https://user-images.githubusercontent.com/100830195/222380718-5447104b-d74c-4d28-b385-acddedfbaf36.png)
 
Таблица сервисов

 ![image](https://user-images.githubusercontent.com/100830195/222381297-d273c37d-04cf-4086-b3a1-cb18d5c6554f.png)
 
После приведения данных к правильной форме, нужно создать базу и занести в нее данные. Проанализировав задание, была создана база данных со следующими таблицами.

![image](https://user-images.githubusercontent.com/100830195/222416719-50fdd53c-b680-49c0-8502-561f2accd175.png)

После заполнения таблиц данными, они стали выглядеть следующим образом

![image](https://user-images.githubusercontent.com/100830195/222417110-59a3b9d1-c156-4a99-9664-0bd5ad2cef6a.png)

![image](https://user-images.githubusercontent.com/100830195/222417139-e4cb2692-4bed-408c-8dbd-60ade0bc48e4.png)

![image](https://user-images.githubusercontent.com/100830195/222417162-f3d5124c-0f8f-4ef2-b2fd-70813df6e4b3.png)

![image](https://user-images.githubusercontent.com/100830195/222417181-5b50fed7-3310-4cd1-9d31-a41cc8cdfc17.png)

# День 2
Первым делом было разработано окно регистрации и окно входа:

![image](https://user-images.githubusercontent.com/100990884/225435041-ef9116a0-8d24-48b4-85c0-5d30744c6c33.png)

![image](https://user-images.githubusercontent.com/100990884/225432482-5d3c98f8-5d98-4cf5-b793-ab9e5ef8ff5e.png)

В строке пароля добавлена кнопка настройки видимости текста для удобства пользователей:

![image](https://user-images.githubusercontent.com/100990884/225432817-56b4da99-3221-43dd-8044-a816a0e806b5.png)

При неверном вводе пароля, пользователю выводится сообщение о колличестве попыток повторного ввода:

![image](https://user-images.githubusercontent.com/100990884/225442140-db74cab9-86e7-41c7-9c14-cbbbdf988d65.png)

После окончания попыток, пользователя перекидывает на другую страницу где требуется ввести капчу для повторной попытки входа:

![image](https://user-images.githubusercontent.com/100990884/225442046-1648e4f3-d495-447b-8b9e-2acfebb96640.png)

Когда таймер заканчивает отсчёт пользователю будет предложени либо прекратить действие программы, либо остаться на 5 минут:

![image](https://user-images.githubusercontent.com/100990884/225433992-13042279-744f-452a-b639-f9962d05ebe6.png)

На главной странице так же присутствует таймер и присутствует страничный вывод данных:

![image](https://user-images.githubusercontent.com/100990884/225434478-91195eff-b35e-425b-afe2-9dfe35a3b160.png)

Для админа существует доступ к истории входа пользователей:

![image](https://user-images.githubusercontent.com/100990884/225434679-4806d73b-a2a4-4114-b601-43cd7ac87b64.png)

# День 3 
Организован вывод данных для таблиц результатов анализов, а также услуг, предоставляесых лабораторией

![image](https://user-images.githubusercontent.com/100830195/225432600-036878bf-f595-4b3b-940a-d17e69fa70be.png)

Вывод услуг:

![image](https://user-images.githubusercontent.com/100830195/225432701-f2b323dc-93d3-45cf-8c62-2dc36e04c255.png)

Вывод результатов:

![image](https://user-images.githubusercontent.com/100830195/225433013-811ac6fe-8c9b-4cd5-908a-9730c007a55c.png)

Разработаны формы добавления редактирования и удаления данных

Добавление услуг:

![image](https://user-images.githubusercontent.com/100830195/225433280-33769a1c-b5a8-4e7d-932a-c8ce07a2fec8.png)

Редактирование и удаление услуг:

![image](https://user-images.githubusercontent.com/100830195/225436637-76381fac-6277-49a9-a841-5b3102baead9.png)

Добавление результатов(выпадающие списки берут поля из соответствующих таблиц):

![image](https://user-images.githubusercontent.com/100830195/225436892-2ca36da2-61ed-4574-a463-86a5221f380a.png)

Редактирование и удаление результатов:

![image](https://user-images.githubusercontent.com/100830195/225437115-b667a5c1-0f4d-4f91-9943-5c010d3ae16d.png)

Поиск по услугам:

![image](https://user-images.githubusercontent.com/100830195/225438720-38979df7-7b0a-4633-922c-85c3e82a6735.png)

Поиск по анализам (можно выбрать по какому столбцу искать при помощи выпадающего списка)

![image](https://user-images.githubusercontent.com/100830195/225438985-962cc726-b403-4ef3-a74c-e83e2fa718e4.png)

В окне услуг присутствует фильтрация по цене, а также сортирока по алфавиту(а-я, я-а) и по цене(по возрастанию и убыванию)

![image](https://user-images.githubusercontent.com/100830195/225439609-3a72c701-e92d-4e55-a090-d54c4df37d11.png)

В окне анализов присутствует сортировка по услугам (а-я, я-а)

![image](https://user-images.githubusercontent.com/100830195/225439805-73afedff-ca84-40cd-9990-579d86b483b1.png)

Для очистки фильтров присутствует отдельная кнопка

