Симонов Иван | 3 курс | 91-я группа
# Требования к проекту "Парковка"
В системе есть 3 типа пользователей: администраторы, сотрудники и водители. Администратор = сотрудник + дополнительный функционал. Сотрудник = водитель + дополнительный функционал. 
Водитель пользуется услугами парковки, просматривая информацию о её заполненности, стоимости и своих посещениях. 
Сотрудник осуществляет контроль за деятельностью на парковке, записывая информацию о сессиях, транспортных средствах и их перемещениях. 
Администратор контролирует базу данных, удаляя устаревшие данные и добавляя новые при перестройке парковки или изменении тарифных планов.


1. **Регистрация пользователя**.
     * Любой пользователь должен иметь возможность создания учётной записи путём ввода ФИО, подтверждения почты, а также задания пароля.
     * Водителю необходимо дополнительно ввести данные банковской карты для дальнейшей оплаты услуг парковки.
2. **Логин/логаут пользователя**
     * Любой пользователь должен иметь возможность входа в систему при помощи ввода почтового адреса и пароля.
     * Любой пользователь должен иметь возможность выхода из системы в любой момент времени.
3. **(INDEX) просмотр списка записей**. Водитель должен иметь возможность просматривать информацию о загруженности парковки и тарифах, сортируя их по стоимости/типу зоны.
4. **(CREATE) создание записи**
     * Сотрудник вводит информацию о транспортных средствах, въезжающих на парковку, и сессиях водителей. Сотрудник также следит за перемещениями транспортных средств по парковке и создаёт записи о них.
     * При расширении парковки администратор может делить новую территорию парковки на зоны, добавляя соответствующие записи.
5. **(READ) просмотр деталей записи**
     * Водитель может просматривать информацию о своих парковочных сессиях. Также он имеет право подробно изучить тарифные планы.
     * Сотрудник имеет доступ к данным транспортных средств, их перемещений и сессий.
     * Администратор имеет доступ к данным всей БД.
6. **(UPDATE) редактирование записи**
     * Все пользователи имеют возможность изменить свои персональные данные.
     * Администратор способен изменить данные о транспортном средстве, его перемещениях и сессии. Кроме того, он может изменять ценовую политику или специализацию зон парковки. 
7. **(DELETE) удаление записи**. Администратор способен удалять записи о транспортных средствах, их перемещениях и сессиях водителей. Кроме того, при необходимости он имеет право удалять зоны парковки.
***
# База данных
![изображение](https://github.com/user-attachments/assets/4271842b-caea-4255-b4f6-7ad14f546241)


