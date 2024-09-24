Симонов Иван 3 курс 91-я группа
# Требования к проекту "Парковка"
В системе есть 3 типа пользователей: администраторы, сотрудники и водители. Администратор = сотрудник + дополнительный функционал. Сотрудник = водитель + дополнительный функционал


4. **(CREATE) создание записи**
     * Сотрудник вводит информацию о транспортных средствах, въезжающих на парковку, и сессиях водителей. Сотрудник также следит за перемещениями транспортных средств по парковке и создаёт записи о них.
     * При расширении парковки администратор может делить новую территорию парковки на зоны, добавляя соответствующие записи.
5. **(READ) просмотр деталей записи**
     * Водитель может просматривать информацию о загруженности парковки и тарифах разных её зон.
     * Сотрудник имеет доступ к данным транспортных средств, их перемещений и сессий.
     * Администратор имеет доступ к данным всей БД.
6. **(UPDATE) редактирование записи**
     * Все пользователи имеют возможность изменить свои персональные данные.
     * Администратор способен изменить данные о транспортном средстве, его перемещениях и сессии. Кроме того, он может изменять ценовую политику или специализацию зон парковки. 
7. **(DELETE) удаление записи**. Администратор способен удалять записи о транспортных средствах, их перемещениях и сессиях водителей. Кроме того, при необходимости он имеет право удалять зоны парковки.
