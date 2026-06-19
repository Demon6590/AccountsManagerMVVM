CREATE TABLE table_persons
(
    id         SERIAL PRIMARY KEY,
    last_name  TEXT    NOT NULL,
    first_name TEXT    NOT NULL,
    patronymic TEXT    NOT NULL,
    is_admin   BOOLEAN NOT NULL DEFAULT FALSE
);

CREATE TABLE table_accounts
(
    id        SERIAL PRIMARY KEY,
    email     TEXT    NOT NULL UNIQUE,
    password  TEXT    NOT NULL,
    person_id INTEGER NOT NULL REFERENCES table_persons (id) ON DELETE CASCADE
);