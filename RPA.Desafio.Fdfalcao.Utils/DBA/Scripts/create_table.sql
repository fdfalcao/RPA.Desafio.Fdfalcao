-- Table: public.rpa_resultado

-- DROP TABLE IF EXISTS public.rpa_resultado;

CREATE TABLE IF NOT EXISTS public.rpa_resultado
(
    wpm_str character varying COLLATE pg_catalog."default" NOT NULL,
    keystrokes_int integer NOT NULL,
    accuracy_str character varying COLLATE pg_catalog."default",
    correctwords_int integer,
    wrongwords_int integer
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.rpa_resultado
    OWNER to postgres;