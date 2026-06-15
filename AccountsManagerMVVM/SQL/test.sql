INSERT INTO table_persons (last_name, first_name, patronymic,isAdmin)
VALUES ('Иванов', 'Иван', 'Иванович',0),
       ('Петрова', 'Анна', 'Сергеевна',0),
       ('Смирнов', 'Алексей', 'Николаевич',0),
       ('Федорова', 'Елена', 'Владимировна',0),
       ('Кузнецов', 'Дмитрий', 'Андреевич',1);
INSERT INTO table_accounts (email, password, person_id)
VALUES ('ivanov.ivan@example.com', '$2a$12$eImiTxAk4bM62o8z', 1),
       ('petrova.anna@example.com', '$2a$12$8K6M7dfYtG9zPq3x', 2),
       ('smirnov.alex@example.com', '$2a$12$9zPq3x8K6M7dfYtG', 3),
       ('fedorova.elena@example.com', '$2a$12$L3k9Pj7mN5bV4cXz', 4),
       ('kuznetsov.dima@example.com', '$2a$12$Q1w2E3r4T5y6U7i8', 5);