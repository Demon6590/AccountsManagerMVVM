CREATE TABLE table_persons
(
    id         INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    last_name  TEXT    NOT NULL,
    first_name TEXT    NOT NULL,
    patronymic TEXT NOT NULL,
    isAdmin BOOLEAN NOT NULL DEFAULT 0
);


CREATE TABLE table_accounts(
    id INTEGER PRIMARY KEY AUTOINCREMENT, 
    email TEXT NOT NULL,
    password TEXT NOT NULL,
    person_id INTEGER NOT NULL REFERENCES table_persons (id)
)