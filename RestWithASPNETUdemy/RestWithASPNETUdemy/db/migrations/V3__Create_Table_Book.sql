CREATE TABLE IF NOT EXISTS "book" (
  "id" serial NOT NULL,
  "author" varchar(100) NOT NULL,
  "launch_date" timestamp(6) NOT NULL,
  "price" decimal(65,2) NOT NULL,
  "title" varchar(255) NOT NULL,
  PRIMARY KEY ("id")
) 