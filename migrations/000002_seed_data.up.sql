INSERT INTO table_persons (last_name, first_name, patronymic, is_admin)
VALUES ('Иванов', 'Иван', 'Иванович', TRUE),
       ('Петров', 'Петр', 'Петрович', FALSE);
INSERT INTO table_accounts (email, password, person_id)
VALUES ('admin@mail.com', 'hash_password_123', 1),
       ('user@mail.com', 'hash_password_456', 2);