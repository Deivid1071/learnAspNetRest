CREATE TABLE IF NOT EXISTS "users" (
  "id" serial NOT NULL,
  "user_name" varchar(50) NOT NULL,
  "password" varchar(130) NOT NULL,
  "full_name" varchar(130) NOT NULL,
  "refresh_token" varchar(500) NOT NULL,
  "refresh_token_expiry_time" timestamp(6) NOT NULL,  
  PRIMARY KEY ("id")
) 

