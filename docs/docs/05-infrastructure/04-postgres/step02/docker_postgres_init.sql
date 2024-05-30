CREATE DATABASE demo1
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'en_US.utf8'
    LC_CTYPE = 'en_US.utf8'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1;

CREATE DATABASE demo2
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'en_US.utf8'
    LC_CTYPE = 'en_US.utf8'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1;

-- CREATE TABLE employees
-- (
--     id SERIAL,
--     name text,
--     title text,
--     CONSTRAINT employees_pkey PRIMARY KEY (id)
-- );

-- INSERT INTO employees(name, title) VALUES
--  ('Meadow Crystalfreak ', 'Head of Operations'),
--  ('Buddy-Ray Perceptor', 'DevRel'),
--  ('Prince Flitterbell', 'Marketing Guru');

-- create a table
CREATE TABLE test(
  id INT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
  name TEXT NOT NULL,
  archived BOOLEAN NOT NULL DEFAULT FALSE
);

-- add test data
INSERT INTO test (name, archived)
  VALUES ('test row 1', true),
  ('test row 2', false);