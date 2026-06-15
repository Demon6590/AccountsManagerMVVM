CREATE VIEW view_persons_and_accounts AS
SELECT  pers.id     AS person_id,
        pers.last_name,
        pers.first_name,
        pers.patronymic,
        account.email,
        account.password
FROM table_persons pers
         JOIN table_accounts account ON pers.id = account.person_id;