--
-- PostgreSQL database dump
--

-- Dumped from database version 11.5 (Ubuntu 11.5-1.pgdg16.04+1)
-- Dumped by pg_dump version 11.4

-- Started on 2019-08-13 09:47:36

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 3995 (class 1262 OID 3311459)
-- Name: d3d1kqf4bqnar8; Type: DATABASE; Schema: -; Owner: otjeadbwenlfkc
--

CREATE DATABASE d3d1kqf4bqnar8 WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'en_US.UTF-8' LC_CTYPE = 'en_US.UTF-8';


ALTER DATABASE d3d1kqf4bqnar8 OWNER TO otjeadbwenlfkc;

\connect d3d1kqf4bqnar8

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 3 (class 2615 OID 2200)
-- Name: public; Type: SCHEMA; Schema: -; Owner: otjeadbwenlfkc
--

CREATE SCHEMA public;


ALTER SCHEMA public OWNER TO otjeadbwenlfkc;

--
-- TOC entry 3997 (class 0 OID 0)
-- Dependencies: 3
-- Name: SCHEMA public; Type: COMMENT; Schema: -; Owner: otjeadbwenlfkc
--

COMMENT ON SCHEMA public IS 'standard public schema';


SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 196 (class 1259 OID 3311955)
-- Name: compras; Type: TABLE; Schema: public; Owner: otjeadbwenlfkc
--

CREATE TABLE public.compras (
    id integer NOT NULL,
    user_id integer NOT NULL,
    horas_compradas numeric(8,2) NOT NULL,
    fecha_compra date NOT NULL,
    monto numeric(8,2) NOT NULL,
    created_at timestamp(0) without time zone,
    updated_at timestamp(0) without time zone
);


ALTER TABLE public.compras OWNER TO otjeadbwenlfkc;

--
-- TOC entry 197 (class 1259 OID 3311958)
-- Name: compras_id_seq; Type: SEQUENCE; Schema: public; Owner: otjeadbwenlfkc
--

CREATE SEQUENCE public.compras_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.compras_id_seq OWNER TO otjeadbwenlfkc;

--
-- TOC entry 4000 (class 0 OID 0)
-- Dependencies: 197
-- Name: compras_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: otjeadbwenlfkc
--

ALTER SEQUENCE public.compras_id_seq OWNED BY public.compras.id;


--
-- TOC entry 198 (class 1259 OID 3311960)
-- Name: estudiantes; Type: TABLE; Schema: public; Owner: otjeadbwenlfkc
--

CREATE TABLE public.estudiantes (
    id integer NOT NULL,
    user_id integer NOT NULL,
    nombre character varying(120) NOT NULL,
    apellido character varying(120) NOT NULL,
    cedula character varying(120) NOT NULL,
    pasaporte character varying(120) NOT NULL,
    f_nacimiento date NOT NULL,
    peso integer NOT NULL,
    estatura numeric(3,2) NOT NULL,
    sexo character(1) NOT NULL,
    grupo_sangre character varying(120) NOT NULL,
    direccion character varying(120) NOT NULL,
    estado character varying(120) NOT NULL,
    municipio character varying(120) NOT NULL,
    ciudad character varying(120) NOT NULL,
    codigo_postal character varying(120) NOT NULL,
    tlf_local character varying(120) NOT NULL,
    tlf_movil character varying(120) NOT NULL,
    correo character varying(120) NOT NULL,
    nombre_emerg character varying(120) NOT NULL,
    tlf1_emerg character varying(120) NOT NULL,
    tlf2_emerg character varying(120) NOT NULL,
    tlf3_emerg character varying(120) NOT NULL,
    tipo_licencia character varying(120) NOT NULL,
    vence_certificado date NOT NULL,
    vence_licencia date NOT NULL,
    horas_externas numeric(8,2) NOT NULL,
    evaluacion_medica character(1) NOT NULL,
    hab_instrumental boolean DEFAULT false NOT NULL,
    hab_monomotor boolean DEFAULT false NOT NULL,
    hab_multimotor boolean DEFAULT false NOT NULL,
    horas_pic numeric(8,2) NOT NULL,
    horas_sic numeric(8,2) NOT NULL,
    created_at timestamp(0) without time zone,
    updated_at timestamp(0) without time zone
);


ALTER TABLE public.estudiantes OWNER TO otjeadbwenlfkc;

--
-- TOC entry 199 (class 1259 OID 3311969)
-- Name: estudiantes_id_seq; Type: SEQUENCE; Schema: public; Owner: otjeadbwenlfkc
--

CREATE SEQUENCE public.estudiantes_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.estudiantes_id_seq OWNER TO otjeadbwenlfkc;

--
-- TOC entry 4001 (class 0 OID 0)
-- Dependencies: 199
-- Name: estudiantes_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: otjeadbwenlfkc
--

ALTER SEQUENCE public.estudiantes_id_seq OWNED BY public.estudiantes.id;


--
-- TOC entry 200 (class 1259 OID 3311971)
-- Name: instructors; Type: TABLE; Schema: public; Owner: otjeadbwenlfkc
--

CREATE TABLE public.instructors (
    id integer NOT NULL,
    user_id integer NOT NULL,
    nombre character varying(120) NOT NULL,
    apellido character varying(120) NOT NULL,
    cedula character varying(120) NOT NULL,
    pasaporte character varying(120) NOT NULL,
    f_nacimiento date NOT NULL,
    peso integer NOT NULL,
    estatura numeric(3,2) NOT NULL,
    sexo character(1) NOT NULL,
    grupo_sangre character varying(120) NOT NULL,
    direccion character varying(120) NOT NULL,
    estado character varying(120) NOT NULL,
    municipio character varying(120) NOT NULL,
    ciudad character varying(120) NOT NULL,
    codigo_postal character varying(120) NOT NULL,
    tlf_local character varying(120) NOT NULL,
    tlf_movil character varying(120) NOT NULL,
    correo character varying(120) NOT NULL,
    nombre_emerg character varying(120) NOT NULL,
    tlf1_emerg character varying(120) NOT NULL,
    tlf2_emerg character varying(120) NOT NULL,
    tlf3_emerg character varying(120) NOT NULL,
    tipo_licencia character varying(120) NOT NULL,
    vence_certificado date NOT NULL,
    vence_licencia date NOT NULL,
    horas_externas numeric(8,2) NOT NULL,
    evaluacion_medica character(1) NOT NULL,
    hab_instrumental boolean DEFAULT false NOT NULL,
    hab_monomotor boolean DEFAULT false NOT NULL,
    hab_multimotor boolean DEFAULT false NOT NULL,
    horas_pic numeric(8,2) NOT NULL,
    horas_sic numeric(8,2) NOT NULL,
    created_at timestamp(0) without time zone,
    updated_at timestamp(0) without time zone
);


ALTER TABLE public.instructors OWNER TO otjeadbwenlfkc;

--
-- TOC entry 201 (class 1259 OID 3311980)
-- Name: instructors_id_seq; Type: SEQUENCE; Schema: public; Owner: otjeadbwenlfkc
--

CREATE SEQUENCE public.instructors_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.instructors_id_seq OWNER TO otjeadbwenlfkc;

--
-- TOC entry 4002 (class 0 OID 0)
-- Dependencies: 201
-- Name: instructors_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: otjeadbwenlfkc
--

ALTER SEQUENCE public.instructors_id_seq OWNED BY public.instructors.id;


--
-- TOC entry 202 (class 1259 OID 3311982)
-- Name: migrations; Type: TABLE; Schema: public; Owner: otjeadbwenlfkc
--

CREATE TABLE public.migrations (
    id integer NOT NULL,
    migration character varying(120) NOT NULL,
    batch integer NOT NULL
);


ALTER TABLE public.migrations OWNER TO otjeadbwenlfkc;

--
-- TOC entry 203 (class 1259 OID 3311985)
-- Name: migrations_id_seq; Type: SEQUENCE; Schema: public; Owner: otjeadbwenlfkc
--

CREATE SEQUENCE public.migrations_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.migrations_id_seq OWNER TO otjeadbwenlfkc;

--
-- TOC entry 4003 (class 0 OID 0)
-- Dependencies: 203
-- Name: migrations_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: otjeadbwenlfkc
--

ALTER SEQUENCE public.migrations_id_seq OWNED BY public.migrations.id;


--
-- TOC entry 204 (class 1259 OID 3311987)
-- Name: password_resets; Type: TABLE; Schema: public; Owner: otjeadbwenlfkc
--

CREATE TABLE public.password_resets (
    email character varying(120) NOT NULL,
    token character varying(120) NOT NULL,
    created_at timestamp(0) without time zone
);


ALTER TABLE public.password_resets OWNER TO otjeadbwenlfkc;

--
-- TOC entry 205 (class 1259 OID 3311990)
-- Name: permission_role; Type: TABLE; Schema: public; Owner: otjeadbwenlfkc
--

CREATE TABLE public.permission_role (
    id integer NOT NULL,
    permission_id integer NOT NULL,
    role_id integer NOT NULL,
    created_at timestamp(0) without time zone,
    updated_at timestamp(0) without time zone
);


ALTER TABLE public.permission_role OWNER TO otjeadbwenlfkc;

--
-- TOC entry 206 (class 1259 OID 3311993)
-- Name: permission_role_id_seq; Type: SEQUENCE; Schema: public; Owner: otjeadbwenlfkc
--

CREATE SEQUENCE public.permission_role_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.permission_role_id_seq OWNER TO otjeadbwenlfkc;

--
-- TOC entry 4004 (class 0 OID 0)
-- Dependencies: 206
-- Name: permission_role_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: otjeadbwenlfkc
--

ALTER SEQUENCE public.permission_role_id_seq OWNED BY public.permission_role.id;


--
-- TOC entry 207 (class 1259 OID 3311995)
-- Name: permission_user; Type: TABLE; Schema: public; Owner: otjeadbwenlfkc
--

CREATE TABLE public.permission_user (
    id integer NOT NULL,
    permission_id integer NOT NULL,
    user_id integer NOT NULL,
    created_at timestamp(0) without time zone,
    updated_at timestamp(0) without time zone
);


ALTER TABLE public.permission_user OWNER TO otjeadbwenlfkc;

--
-- TOC entry 208 (class 1259 OID 3311998)
-- Name: permission_user_id_seq; Type: SEQUENCE; Schema: public; Owner: otjeadbwenlfkc
--

CREATE SEQUENCE public.permission_user_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.permission_user_id_seq OWNER TO otjeadbwenlfkc;

--
-- TOC entry 4005 (class 0 OID 0)
-- Dependencies: 208
-- Name: permission_user_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: otjeadbwenlfkc
--

ALTER SEQUENCE public.permission_user_id_seq OWNED BY public.permission_user.id;


--
-- TOC entry 209 (class 1259 OID 3312000)
-- Name: permissions; Type: TABLE; Schema: public; Owner: otjeadbwenlfkc
--

CREATE TABLE public.permissions (
    id integer NOT NULL,
    name character varying(120) NOT NULL,
    slug character varying(120) NOT NULL,
    description text,
    created_at timestamp(0) without time zone,
    updated_at timestamp(0) without time zone
);


ALTER TABLE public.permissions OWNER TO otjeadbwenlfkc;

--
-- TOC entry 210 (class 1259 OID 3312006)
-- Name: permissions_id_seq; Type: SEQUENCE; Schema: public; Owner: otjeadbwenlfkc
--

CREATE SEQUENCE public.permissions_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.permissions_id_seq OWNER TO otjeadbwenlfkc;

--
-- TOC entry 4006 (class 0 OID 0)
-- Dependencies: 210
-- Name: permissions_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: otjeadbwenlfkc
--

ALTER SEQUENCE public.permissions_id_seq OWNED BY public.permissions.id;


--
-- TOC entry 211 (class 1259 OID 3312008)
-- Name: products; Type: TABLE; Schema: public; Owner: otjeadbwenlfkc
--

CREATE TABLE public.products (
    id integer NOT NULL,
    name character varying(120) NOT NULL,
    description character varying(120) NOT NULL,
    created_at timestamp(0) without time zone,
    updated_at timestamp(0) without time zone
);


ALTER TABLE public.products OWNER TO otjeadbwenlfkc;

--
-- TOC entry 212 (class 1259 OID 3312011)
-- Name: products_id_seq; Type: SEQUENCE; Schema: public; Owner: otjeadbwenlfkc
--

CREATE SEQUENCE public.products_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.products_id_seq OWNER TO otjeadbwenlfkc;

--
-- TOC entry 4007 (class 0 OID 0)
-- Dependencies: 212
-- Name: products_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: otjeadbwenlfkc
--

ALTER SEQUENCE public.products_id_seq OWNED BY public.products.id;


--
-- TOC entry 213 (class 1259 OID 3312013)
-- Name: role_user; Type: TABLE; Schema: public; Owner: otjeadbwenlfkc
--

CREATE TABLE public.role_user (
    id integer NOT NULL,
    role_id integer NOT NULL,
    user_id integer NOT NULL,
    created_at timestamp(0) without time zone,
    updated_at timestamp(0) without time zone
);


ALTER TABLE public.role_user OWNER TO otjeadbwenlfkc;

--
-- TOC entry 214 (class 1259 OID 3312016)
-- Name: role_user_id_seq; Type: SEQUENCE; Schema: public; Owner: otjeadbwenlfkc
--

CREATE SEQUENCE public.role_user_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.role_user_id_seq OWNER TO otjeadbwenlfkc;

--
-- TOC entry 4008 (class 0 OID 0)
-- Dependencies: 214
-- Name: role_user_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: otjeadbwenlfkc
--

ALTER SEQUENCE public.role_user_id_seq OWNED BY public.role_user.id;


--
-- TOC entry 215 (class 1259 OID 3312018)
-- Name: roles; Type: TABLE; Schema: public; Owner: otjeadbwenlfkc
--

CREATE TABLE public.roles (
    id integer NOT NULL,
    name character varying(120) NOT NULL,
    slug character varying(120) NOT NULL,
    description text,
    created_at timestamp(0) without time zone,
    updated_at timestamp(0) without time zone,
    special character varying(255),
    CONSTRAINT roles_special_check CHECK (((special)::text = ANY (ARRAY[('all-access'::character varying)::text, ('no-access'::character varying)::text])))
);


ALTER TABLE public.roles OWNER TO otjeadbwenlfkc;

--
-- TOC entry 216 (class 1259 OID 3312025)
-- Name: roles_id_seq; Type: SEQUENCE; Schema: public; Owner: otjeadbwenlfkc
--

CREATE SEQUENCE public.roles_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.roles_id_seq OWNER TO otjeadbwenlfkc;

--
-- TOC entry 4009 (class 0 OID 0)
-- Dependencies: 216
-- Name: roles_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: otjeadbwenlfkc
--

ALTER SEQUENCE public.roles_id_seq OWNED BY public.roles.id;


--
-- TOC entry 217 (class 1259 OID 3312027)
-- Name: users; Type: TABLE; Schema: public; Owner: otjeadbwenlfkc
--

CREATE TABLE public.users (
    id integer NOT NULL,
    name character varying(120) NOT NULL,
    email character varying(120) NOT NULL,
    password character varying(120) NOT NULL,
    remember_token character varying(100),
    created_at timestamp(0) without time zone,
    updated_at timestamp(0) without time zone
);


ALTER TABLE public.users OWNER TO otjeadbwenlfkc;

--
-- TOC entry 218 (class 1259 OID 3312030)
-- Name: users_id_seq; Type: SEQUENCE; Schema: public; Owner: otjeadbwenlfkc
--

CREATE SEQUENCE public.users_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.users_id_seq OWNER TO otjeadbwenlfkc;

--
-- TOC entry 4010 (class 0 OID 0)
-- Dependencies: 218
-- Name: users_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: otjeadbwenlfkc
--

ALTER SEQUENCE public.users_id_seq OWNED BY public.users.id;


--
-- TOC entry 219 (class 1259 OID 3312032)
-- Name: vuelos; Type: TABLE; Schema: public; Owner: otjeadbwenlfkc
--

CREATE TABLE public.vuelos (
    id integer NOT NULL,
    id_estudiante integer NOT NULL,
    id_instructor integer NOT NULL,
    horas_voladas numeric(8,2) NOT NULL,
    fecha_vuelo date NOT NULL,
    modalidad character varying(120) NOT NULL,
    horas_helice numeric(8,2) NOT NULL,
    horas_aceite numeric(8,2) NOT NULL,
    horas_fuselaje numeric(8,2) NOT NULL,
    horas_bujias numeric(8,2) NOT NULL,
    avion character varying(120) NOT NULL,
    created_at timestamp(0) without time zone,
    updated_at timestamp(0) without time zone
);


ALTER TABLE public.vuelos OWNER TO otjeadbwenlfkc;

--
-- TOC entry 220 (class 1259 OID 3312035)
-- Name: vuelos_id_seq; Type: SEQUENCE; Schema: public; Owner: otjeadbwenlfkc
--

CREATE SEQUENCE public.vuelos_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.vuelos_id_seq OWNER TO otjeadbwenlfkc;

--
-- TOC entry 4011 (class 0 OID 0)
-- Dependencies: 220
-- Name: vuelos_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: otjeadbwenlfkc
--

ALTER SEQUENCE public.vuelos_id_seq OWNED BY public.vuelos.id;


--
-- TOC entry 3775 (class 2604 OID 3312037)
-- Name: compras id; Type: DEFAULT; Schema: public; Owner: otjeadbwenlfkc
--

ALTER TABLE ONLY public.compras ALTER COLUMN id SET DEFAULT nextval('public.compras_id_seq'::regclass);


--
-- TOC entry 3779 (class 2604 OID 3312038)
-- Name: estudiantes id; Type: DEFAULT; Schema: public; Owner: otjeadbwenlfkc
--

ALTER TABLE ONLY public.estudiantes ALTER COLUMN id SET DEFAULT nextval('public.estudiantes_id_seq'::regclass);


--
-- TOC entry 3783 (class 2604 OID 3312039)
-- Name: instructors id; Type: DEFAULT; Schema: public; Owner: otjeadbwenlfkc
--

ALTER TABLE ONLY public.instructors ALTER COLUMN id SET DEFAULT nextval('public.instructors_id_seq'::regclass);


--
-- TOC entry 3784 (class 2604 OID 3312040)
-- Name: migrations id; Type: DEFAULT; Schema: public; Owner: otjeadbwenlfkc
--

ALTER TABLE ONLY public.migrations ALTER COLUMN id SET DEFAULT nextval('public.migrations_id_seq'::regclass);


--
-- TOC entry 3785 (class 2604 OID 3312041)
-- Name: permission_role id; Type: DEFAULT; Schema: public; Owner: otjeadbwenlfkc
--

ALTER TABLE ONLY public.permission_role ALTER COLUMN id SET DEFAULT nextval('public.permission_role_id_seq'::regclass);


--
-- TOC entry 3786 (class 2604 OID 3312042)
-- Name: permission_user id; Type: DEFAULT; Schema: public; Owner: otjeadbwenlfkc
--

ALTER TABLE ONLY public.permission_user ALTER COLUMN id SET DEFAULT nextval('public.permission_user_id_seq'::regclass);


--
-- TOC entry 3787 (class 2604 OID 3312043)
-- Name: permissions id; Type: DEFAULT; Schema: public; Owner: otjeadbwenlfkc
--

ALTER TABLE ONLY public.permissions ALTER COLUMN id SET DEFAULT nextval('public.permissions_id_seq'::regclass);


--
-- TOC entry 3788 (class 2604 OID 3312044)
-- Name: products id; Type: DEFAULT; Schema: public; Owner: otjeadbwenlfkc
--

ALTER TABLE ONLY public.products ALTER COLUMN id SET DEFAULT nextval('public.products_id_seq'::regclass);


--
-- TOC entry 3789 (class 2604 OID 3312045)
-- Name: role_user id; Type: DEFAULT; Schema: public; Owner: otjeadbwenlfkc
--

ALTER TABLE ONLY public.role_user ALTER COLUMN id SET DEFAULT nextval('public.role_user_id_seq'::regclass);


--
-- TOC entry 3790 (class 2604 OID 3312046)
-- Name: roles id; Type: DEFAULT; Schema: public; Owner: otjeadbwenlfkc
--

ALTER TABLE ONLY public.roles ALTER COLUMN id SET DEFAULT nextval('public.roles_id_seq'::regclass);


--
-- TOC entry 3792 (class 2604 OID 3312047)
-- Name: users id; Type: DEFAULT; Schema: public; Owner: otjeadbwenlfkc
--

ALTER TABLE ONLY public.users ALTER COLUMN id SET DEFAULT nextval('public.users_id_seq'::regclass);


--
-- TOC entry 3793 (class 2604 OID 3312048)
-- Name: vuelos id; Type: DEFAULT; Schema: public; Owner: otjeadbwenlfkc
--

ALTER TABLE ONLY public.vuelos ALTER COLUMN id SET DEFAULT nextval('public.vuelos_id_seq'::regclass);


--
-- TOC entry 3965 (class 0 OID 3311955)
-- Dependencies: 196
-- Data for Name: compras; Type: TABLE DATA; Schema: public; Owner: otjeadbwenlfkc
--

INSERT INTO public.compras VALUES (1, 4, 20.00, '2019-07-12', 100.00, '2019-07-12 14:30:37', '2019-07-12 14:30:37');
INSERT INTO public.compras VALUES (2, 9, 20.00, '2019-07-30', 2600.00, '2019-07-30 14:06:13', '2019-07-30 14:06:13');
INSERT INTO public.compras VALUES (3, 22, 40.00, '2019-05-13', 4800.00, '2019-07-31 14:25:29', '2019-07-31 14:25:29');
INSERT INTO public.compras VALUES (4, 21, 40.00, '2019-04-01', 4000.00, '2019-07-31 17:27:15', '2019-07-31 17:27:15');
INSERT INTO public.compras VALUES (5, 17, 20.00, '2019-06-11', 2400.00, '2019-07-31 17:28:49', '2019-07-31 17:28:49');
INSERT INTO public.compras VALUES (6, 14, 20.00, '2019-06-28', 2200.00, '2019-08-01 14:27:34', '2019-08-01 14:27:34');
INSERT INTO public.compras VALUES (7, 23, 90.00, '2018-09-24', 9000.00, '2019-08-01 14:28:57', '2019-08-01 14:28:57');
INSERT INTO public.compras VALUES (8, 18, 10.00, '2019-06-28', 1300.00, '2019-08-01 14:40:44', '2019-08-01 14:40:44');
INSERT INTO public.compras VALUES (9, 16, 20.00, '2019-07-02', 2600.00, '2019-08-01 14:44:35', '2019-08-01 14:44:35');


--
-- TOC entry 3967 (class 0 OID 3311960)
-- Dependencies: 198
-- Data for Name: estudiantes; Type: TABLE DATA; Schema: public; Owner: otjeadbwenlfkc
--

INSERT INTO public.estudiantes VALUES (4, 4, 'Miguel', 'Carrozza', 'v25737754', '000', '1993-07-31', 83, 1.72, 'M', 'A+', 'Lecheria', 'Anzoategui', 'Urbaneja', 'Lecheria', '6016', '000', '04249504945', 'carrozzapilot@gmail.com', 'Olga Olivero', '04149966469', '02915451296', '02925451211', 'alumno', '2020-07-01', '2020-07-01', 0.00, 'S', true, true, false, 600.00, 200.00, '2019-07-12 14:16:54', '2019-07-12 14:17:59');
INSERT INTO public.estudiantes VALUES (6, 22, 'erick', 'cabrera', '22864601', '000', '1970-01-01', 68, 1.70, 'M', 'O+', 'puerto la cruz', 'anzoategui', 'sotillo', 'vidoño', '6016', '000', '04129879479', 'erickcabrera.1994@hotmail.com', 'luis bello', '04248468709', '000', '000', 'alumno', '2021-03-25', '2020-06-03', 0.00, 'S', false, true, false, 0.00, 11.30, '2019-07-31 15:14:00', '2019-07-31 15:14:00');
INSERT INTO public.estudiantes VALUES (7, 21, 'anthony', 'tua', '19813057', '000', '1992-04-24', 113, 1.76, 'M', 'O+', 'puerto la cruz', 'anzoategui', '000', '000', '6016', '000', '04248742128', 'anthonytua@gmail.com', 'papa', '04148093756', '000', '000', 'alumno', '2020-04-03', '2019-04-03', 0.00, 'S', false, true, false, 0.00, 18.20, '2019-07-31 17:15:31', '2019-07-31 17:15:31');
INSERT INTO public.estudiantes VALUES (9, 20, 'cesar', 'andrade', '29899485', '000', '1970-01-01', 90, 1.93, 'M', 'O+', 'guaraguao', 'anzoategui', 'sotillo', 'puerto la cruz', '6016', '04147695256', '000', 'cesarrosales27@outlook.com', 'osmary rosales', '04141896933', '000', '000', 'alumno', '1970-01-01', '1970-01-01', 0.00, 'S', false, true, false, 0.00, 7.10, '2019-07-31 17:26:24', '2019-07-31 17:26:24');
INSERT INTO public.estudiantes VALUES (10, 17, 'raul', 'socorro', '000', '000', '1970-01-01', 70, 1.70, 'M', 'O+', 'lecheria', 'anzoategui', 'urbaneja', 'Lecheria', '6016', '000', '000', 'amaluz14@gmail.com', '000', '000', '000', '000', 'alumno', '1970-01-01', '1970-01-01', 0.00, 'S', true, false, false, 0.00, 41.00, '2019-07-31 17:31:11', '2019-07-31 17:31:11');
INSERT INTO public.estudiantes VALUES (11, 23, 'miguel', 'hanoum', '27072763', '000', '1970-01-01', 70, 1.70, 'M', 'O+', 'lecheria', 'anzoategui', 'urbaneja', 'Lecheria', '6016', '000', '04248563594', 'hanoummiguel@gmail.com', '000', '000', '000', '000', 'alumno', '1970-01-01', '1970-01-01', 0.00, 'S', true, false, false, 0.00, 66.10, '2019-08-01 12:37:35', '2019-08-01 12:37:35');
INSERT INTO public.estudiantes VALUES (12, 14, 'juan pablo', 'frontado', '000', '000', '1970-01-01', 65, 1.70, 'M', 'O+', 'caracas', 'distrito federal', 'chacao', 'caracas', '000', '000', '000', '000', '000', '000', '000', '000', 'alumno', '1970-01-01', '1970-01-01', 0.00, 'S', false, true, false, 0.00, 0.00, '2019-08-01 14:26:12', '2019-08-01 14:26:12');
INSERT INTO public.estudiantes VALUES (13, 18, 'johan', 'rosales', '27.823.776', '000', '1999-12-03', 65, 1.82, 'M', 'O+', 'PUERTO PIRITU', 'anzoategui', 'peñalver', 'piritu', '6001', '04128772001', '000', 'amaluz14@gmail.com', 'papa', '04148328667', '000', '000', 'alumno', '1970-01-01', '1970-01-01', 0.00, 'S', false, true, false, 0.00, 0.00, '2019-08-01 14:39:47', '2019-08-01 14:39:47');
INSERT INTO public.estudiantes VALUES (14, 16, 'carlos', 'pino', '26.284.597', '000', '1970-01-01', 75, 1.70, 'M', 'A+', 'puerto la cruz', 'anzoategui', 'sotillo', 'puerto la cruz', '6000', '000', '000', 'carlospinox@gmail.com', '000', '000', '000', '000', 'privado', '1970-01-01', '1970-01-01', 0.00, 'S', true, false, false, 2.00, 41.00, '2019-08-01 14:43:51', '2019-08-01 14:43:51');


--
-- TOC entry 3969 (class 0 OID 3311971)
-- Dependencies: 200
-- Data for Name: instructors; Type: TABLE DATA; Schema: public; Owner: otjeadbwenlfkc
--

INSERT INTO public.instructors VALUES (1, 1, 'wadih', 'zouhairi', 'v1234', '000', '1981-08-08', 90, 1.88, 'M', 'A+', 'lecheria', 'anzoategui', 'urbaneja', 'lecheria', '6016', '0281123456', '04120863989', 'wadih08088@gmail.com', 'c', '04148200327', '000', '000', 'comercial', '2020-03-03', '2020-03-03', 0.00, 'S', true, true, true, 1200.00, 200.00, '2019-07-12 14:28:42', '2019-07-12 14:28:42');
INSERT INTO public.instructors VALUES (2, 5, 'Ricardo', 'Maldonado', 'v26346968', '000', '1998-11-03', 76, 1.77, 'M', 'A+', 'las palmeras', 'anzoategui', 'urbaneja', 'lecheria', '6016', '02812825064', '04261858858', 'Uefamaldonado@hotmail.com', 'fernan maldonado', '04164835408', '04147926063', '000', 'alumno', '2020-06-03', '2020-06-03', 0.00, 'S', true, true, true, 550.00, 150.00, '2019-07-12 14:47:03', '2019-07-30 14:09:40');


--
-- TOC entry 3971 (class 0 OID 3311982)
-- Dependencies: 202
-- Data for Name: migrations; Type: TABLE DATA; Schema: public; Owner: otjeadbwenlfkc
--

INSERT INTO public.migrations VALUES (1, '2014_10_12_000000_create_users_table', 1);
INSERT INTO public.migrations VALUES (2, '2014_10_12_100000_create_password_resets_table', 1);
INSERT INTO public.migrations VALUES (3, '2015_01_20_084450_create_roles_table', 1);
INSERT INTO public.migrations VALUES (4, '2015_01_20_084525_create_role_user_table', 1);
INSERT INTO public.migrations VALUES (5, '2015_01_24_080208_create_permissions_table', 1);
INSERT INTO public.migrations VALUES (6, '2015_01_24_080433_create_permission_role_table', 1);
INSERT INTO public.migrations VALUES (7, '2015_12_04_003040_add_special_role_column', 1);
INSERT INTO public.migrations VALUES (8, '2017_10_17_170735_create_permission_user_table', 1);
INSERT INTO public.migrations VALUES (9, '2018_06_05_104139_create_products_table', 1);
INSERT INTO public.migrations VALUES (10, '2018_06_21_235832_create_estudiantes_table', 1);
INSERT INTO public.migrations VALUES (11, '2018_07_03_053031_create_instructors_table', 1);
INSERT INTO public.migrations VALUES (12, '2018_07_05_125843_create_compras_table', 1);
INSERT INTO public.migrations VALUES (13, '2018_07_06_113446_create_vuelos_table', 1);


--
-- TOC entry 3973 (class 0 OID 3311987)
-- Dependencies: 204
-- Data for Name: password_resets; Type: TABLE DATA; Schema: public; Owner: otjeadbwenlfkc
--

INSERT INTO public.password_resets VALUES ('amaluz14@gmail.com', '$2y$10$OlxIuXsuMoVZwMhN/cYhXe9OYYR6kl3s//7GBtHYrV5hwy5ctxntC', '2019-07-30 13:53:42');


--
-- TOC entry 3974 (class 0 OID 3311990)
-- Dependencies: 205
-- Data for Name: permission_role; Type: TABLE DATA; Schema: public; Owner: otjeadbwenlfkc
--

INSERT INTO public.permission_role VALUES (1, 1, 5, '2019-07-13 16:35:30', '2019-07-13 16:35:30');
INSERT INTO public.permission_role VALUES (2, 2, 5, '2019-07-13 16:35:30', '2019-07-13 16:35:30');
INSERT INTO public.permission_role VALUES (3, 3, 5, '2019-07-13 16:35:30', '2019-07-13 16:35:30');
INSERT INTO public.permission_role VALUES (4, 5, 5, '2019-07-13 16:35:30', '2019-07-13 16:35:30');
INSERT INTO public.permission_role VALUES (5, 6, 5, '2019-07-13 16:35:30', '2019-07-13 16:35:30');
INSERT INTO public.permission_role VALUES (6, 10, 5, '2019-07-13 16:35:30', '2019-07-13 16:35:30');
INSERT INTO public.permission_role VALUES (7, 11, 5, '2019-07-13 16:35:30', '2019-07-13 16:35:30');
INSERT INTO public.permission_role VALUES (8, 12, 5, '2019-07-13 16:35:30', '2019-07-13 16:35:30');
INSERT INTO public.permission_role VALUES (9, 13, 5, '2019-07-13 16:35:30', '2019-07-13 16:35:30');
INSERT INTO public.permission_role VALUES (10, 15, 5, '2019-07-13 16:35:30', '2019-07-13 16:35:30');
INSERT INTO public.permission_role VALUES (11, 16, 5, '2019-07-13 16:35:30', '2019-07-13 16:35:30');
INSERT INTO public.permission_role VALUES (12, 18, 5, '2019-07-13 16:35:30', '2019-07-13 16:35:30');
INSERT INTO public.permission_role VALUES (13, 20, 5, '2019-07-13 16:35:30', '2019-07-13 16:35:30');
INSERT INTO public.permission_role VALUES (14, 21, 5, '2019-07-13 16:35:30', '2019-07-13 16:35:30');
INSERT INTO public.permission_role VALUES (15, 22, 5, '2019-07-13 16:35:30', '2019-07-13 16:35:30');
INSERT INTO public.permission_role VALUES (16, 23, 5, '2019-07-13 16:35:30', '2019-07-13 16:35:30');
INSERT INTO public.permission_role VALUES (17, 25, 5, '2019-07-13 16:35:30', '2019-07-13 16:35:30');
INSERT INTO public.permission_role VALUES (18, 26, 5, '2019-07-13 16:35:30', '2019-07-13 16:35:30');
INSERT INTO public.permission_role VALUES (19, 27, 5, '2019-07-13 16:35:30', '2019-07-13 16:35:30');
INSERT INTO public.permission_role VALUES (20, 28, 5, '2019-07-13 16:35:30', '2019-07-13 16:35:30');
INSERT INTO public.permission_role VALUES (21, 30, 5, '2019-07-13 16:35:30', '2019-07-13 16:35:30');


--
-- TOC entry 3976 (class 0 OID 3311995)
-- Dependencies: 207
-- Data for Name: permission_user; Type: TABLE DATA; Schema: public; Owner: otjeadbwenlfkc
--



--
-- TOC entry 3978 (class 0 OID 3312000)
-- Dependencies: 209
-- Data for Name: permissions; Type: TABLE DATA; Schema: public; Owner: otjeadbwenlfkc
--

INSERT INTO public.permissions VALUES (1, 'Navegar usuarios', 'users.index', 'Lista y navega todos los usuarios del sistema', '2019-07-12 18:26:07', '2019-07-12 18:26:07');
INSERT INTO public.permissions VALUES (2, 'Ver detalle de usuario', 'users.show', 'Ver en detalle cada usuario del sistema', '2019-07-12 18:26:07', '2019-07-12 18:26:07');
INSERT INTO public.permissions VALUES (3, 'Edición de usuarios', 'users.edit', 'Editar cualquier dato de un usuario del sistema', '2019-07-12 18:26:07', '2019-07-12 18:26:07');
INSERT INTO public.permissions VALUES (4, 'Eliminar usuarios', 'users.destroy', 'Eliminar cualquier usuario del sistema', '2019-07-12 18:26:07', '2019-07-12 18:26:07');
INSERT INTO public.permissions VALUES (5, 'Navegar roles', 'roles.index', 'Lista y navega todos los roles del sistema', '2019-07-12 18:26:07', '2019-07-12 18:26:07');
INSERT INTO public.permissions VALUES (6, 'Ver detalle de rol', 'roles.show', 'Ver en detalle cada rol del sistema', '2019-07-12 18:26:07', '2019-07-12 18:26:07');
INSERT INTO public.permissions VALUES (7, 'Creación de roles', 'roles.create', 'Crear los datos de un rol del sistema', '2019-07-12 18:26:07', '2019-07-12 18:26:07');
INSERT INTO public.permissions VALUES (8, 'Edición de roles', 'roles.edit', 'Editar cualquier dato de un rol del sistema', '2019-07-12 18:26:07', '2019-07-12 18:26:07');
INSERT INTO public.permissions VALUES (9, 'Eliminar rol', 'roles.destroy', 'Eliminar cualquier rol del sistema', '2019-07-12 18:26:07', '2019-07-12 18:26:07');
INSERT INTO public.permissions VALUES (10, 'Navegar estudiantes', 'estudiantes.index', 'Lista y navega todos los estudiantes del sistema', '2019-07-12 18:26:07', '2019-07-12 18:26:07');
INSERT INTO public.permissions VALUES (11, 'Ver detalle de estudiante', 'estudiantes.show', 'Ver en detalle cada estudiante del sistema', '2019-07-12 18:26:07', '2019-07-12 18:26:07');
INSERT INTO public.permissions VALUES (12, 'Creación de estudiantes', 'estudiantes.create', 'Crear los datos de un estudiante del sistema', '2019-07-12 18:26:07', '2019-07-12 18:26:07');
INSERT INTO public.permissions VALUES (13, 'Edición de estudiantes', 'estudiantes.edit', 'Editar cualquier dato de un estudiante del sistema', '2019-07-12 18:26:07', '2019-07-12 18:26:07');
INSERT INTO public.permissions VALUES (14, 'Eliminar estudiante', 'estudiantes.destroy', 'Eliminar cualquier estudiante del sistema', '2019-07-12 18:26:07', '2019-07-12 18:26:07');
INSERT INTO public.permissions VALUES (15, 'Navegar instructores', 'instructors.index', 'Lista y navega todos los instructores del sistema', '2019-07-12 18:26:07', '2019-07-12 18:26:07');
INSERT INTO public.permissions VALUES (16, 'Ver detalle de instructor', 'instructors.show', 'Ver en detalle cada instructor del sistema', '2019-07-12 18:26:07', '2019-07-12 18:26:07');
INSERT INTO public.permissions VALUES (17, 'Creación de instructores', 'instructors.create', 'Crear los datos de un instructor del sistema', '2019-07-12 18:26:07', '2019-07-12 18:26:07');
INSERT INTO public.permissions VALUES (18, 'Edición de instructores', 'instructors.edit', 'Editar cualquier dato de un instructor del sistema', '2019-07-12 18:26:07', '2019-07-12 18:26:07');
INSERT INTO public.permissions VALUES (19, 'Eliminar instructor', 'instructors.destroy', 'Eliminar cualquier instructor del sistema', '2019-07-12 18:26:07', '2019-07-12 18:26:07');
INSERT INTO public.permissions VALUES (20, 'Navegar horas compradas', 'compras.index', 'Lista y navega todas las horas compradas en el sistema', '2019-07-12 18:26:07', '2019-07-12 18:26:07');
INSERT INTO public.permissions VALUES (21, 'Ver detalle de horas compradas', 'compras.show', 'Ver en detalle cada hora comprada en el sistema', '2019-07-12 18:26:07', '2019-07-12 18:26:07');
INSERT INTO public.permissions VALUES (22, 'Creación de horas compradas', 'compras.create', 'Crear los datos de una hora comprada en el sistema', '2019-07-12 18:26:07', '2019-07-12 18:26:07');
INSERT INTO public.permissions VALUES (23, 'Edición de horas compradas', 'compras.edit', 'Editar cualquier dato de una hora en el sistema', '2019-07-12 18:26:07', '2019-07-12 18:26:07');
INSERT INTO public.permissions VALUES (24, 'Eliminar horas compradas', 'compras.destroy', 'Eliminar cualquier hora en el sistema', '2019-07-12 18:26:07', '2019-07-12 18:26:07');
INSERT INTO public.permissions VALUES (25, 'Navegar vuelos realizados', 'vuelos.index', 'Lista y navega todos los vuelos realizados en el sistema', '2019-07-12 18:26:07', '2019-07-12 18:26:07');
INSERT INTO public.permissions VALUES (26, 'Ver detalle de vuelos realizados', 'vuelos.show', 'Ver en detalle cada vuelo realizado en el sistema', '2019-07-12 18:26:07', '2019-07-12 18:26:07');
INSERT INTO public.permissions VALUES (27, 'Creación de vuelo realizado', 'vuelos.create', 'Crear los datos de un vuelo realizado en el sistema', '2019-07-12 18:26:07', '2019-07-12 18:26:07');
INSERT INTO public.permissions VALUES (28, 'Edición de vuelo realizado', 'vuelos.edit', 'Editar cualquier dato de un vuelo realizado en el sistema', '2019-07-12 18:26:07', '2019-07-12 18:26:07');
INSERT INTO public.permissions VALUES (29, 'Eliminar vuelo realizado', 'vuelos.destroy', 'Eliminar cualquier vuelo realizado en el sistema', '2019-07-12 18:26:07', '2019-07-12 18:26:07');
INSERT INTO public.permissions VALUES (30, 'Navegar las horas disponibles por piloto (cartelera)', 'horascontrol.index', 'Lista y navega todas las horas de vuelo disponibles de los pilotos del sistema', '2019-07-12 18:26:07', '2019-07-12 18:26:07');


--
-- TOC entry 3980 (class 0 OID 3312008)
-- Dependencies: 211
-- Data for Name: products; Type: TABLE DATA; Schema: public; Owner: otjeadbwenlfkc
--



--
-- TOC entry 3982 (class 0 OID 3312013)
-- Dependencies: 213
-- Data for Name: role_user; Type: TABLE DATA; Schema: public; Owner: otjeadbwenlfkc
--

INSERT INTO public.role_user VALUES (4, 4, 1, NULL, NULL);
INSERT INTO public.role_user VALUES (5, 4, 5, '2019-07-12 18:33:24', '2019-07-12 18:33:24');
INSERT INTO public.role_user VALUES (6, 5, 7, '2019-07-13 16:35:44', '2019-07-13 16:35:44');
INSERT INTO public.role_user VALUES (8, 4, 8, '2019-07-30 13:55:12', '2019-07-30 13:55:12');


--
-- TOC entry 3984 (class 0 OID 3312018)
-- Dependencies: 215
-- Data for Name: roles; Type: TABLE DATA; Schema: public; Owner: otjeadbwenlfkc
--

INSERT INTO public.roles VALUES (4, 'Admin', 'admin', NULL, '2019-07-12 18:26:07', '2019-07-12 18:26:07', 'all-access');
INSERT INTO public.roles VALUES (5, 'Instructor', 'instructor', 'Los intructores pueden hacer todo menos eliminar registros', '2019-07-13 16:35:30', '2019-07-13 16:35:30', NULL);


--
-- TOC entry 3986 (class 0 OID 3312027)
-- Dependencies: 217
-- Data for Name: users; Type: TABLE DATA; Schema: public; Owner: otjeadbwenlfkc
--

INSERT INTO public.users VALUES (2, 'admin', 'admin@abc.com', '$2y$10$iLC0WOE1xeqxQ/dsaVCQx.4Kql8R/7.OVdS2E4cr3wHV/ICeBGB/O', 'NCMKEoCcqN7otfWqADU29DwqPLHQyfQ4C3BahvzFveCmyQs4zSiagr4yYPC6', '2019-07-11 14:57:17', '2019-07-11 14:57:17');
INSERT INTO public.users VALUES (4, 'Miguel Carrozza', 'carrozzapilot@gmail.com', '$2y$10$fQ9VDb7weXDJIDyNBgcpoeaN9sZprykC9tklUALdziL5fDSic12y2', 'SMBlmxBMXYUmigxrqDQnjDw6IqU3EU3mDurWSDK0IjTjgl9DVwVBOiwewGBW', '2019-07-12 13:44:51', '2019-07-12 13:44:51');
INSERT INTO public.users VALUES (3, 'Luis Rivero', 'riveromontes@gmail.com', '$2y$10$Gwf0dNA5VuNu7b6r0Mt7WO.sbZ8jX.Ee.RRoiR4V9ZLX/6UXkzCQK', '3KG80YFEBZJIJhl9Rb3r3Gh4eSBx3pP5xfV4mlDxV4gVkPiMjo5EgnZBy4Zt', '2019-07-11 15:13:03', '2019-07-11 15:13:03');
INSERT INTO public.users VALUES (7, 'Ignacio Elosua', 'ignition.cap@gmail.com', '$2y$10$CQY.j7nHLk8SAiYPorHv4OHTMJVUSL7ePvw8c29wLfJysQ9/Q0daC', 'vSqcQchCnocWj5KKz9mvA5oA1M9oA8gnGSzyRCQcYBjlEDd4sC4E94nsXe0O', '2019-07-13 16:29:54', '2019-07-13 16:29:54');
INSERT INTO public.users VALUES (5, 'Ricardo Maldonado', 'uefamaldonado@hotmail.com', '$2y$10$PgnCmWyQ6DKFNSxaVtXRRuCE8vKrahf/FOPEQCqkoi5C51NYIyUru', '0LQ5dK8rcWZyMlA22MawVdj1qBCeLzy6daCtR7oM3JyuZUntFE8TAkCqsIqn', '2019-07-12 14:38:03', '2019-07-12 14:38:03');
INSERT INTO public.users VALUES (22, 'erick cabrera', 'erickcabrera.1994@hotmail.com', '$2y$10$rTyYcwAixRLcmlNym5TNnu8AWkakg6Y5PyqV2JbWqgk2YpbFX.18e', 'EMRzz7XXM4TA6yxwdjgpRV1fAgFeWML425xv7IirWyBL7RkTYH58M4g19p2G', '2019-07-31 14:23:51', '2019-07-31 14:23:51');
INSERT INTO public.users VALUES (9, 'igor nebola', 'ciacabna@hotmail.com', '$2y$10$AANHCGziqdlQq9zIiuEVmuDKt31ZNsxYJyzguu3KsHCQu0VTct1/i', 'eHI1ndXCK5Las5EkQmHd1Ov2p99pp1GE51nusTvRepiM2VBUeQTy0Z4Vmzoa', '2019-07-30 14:00:27', '2019-07-30 14:00:27');
INSERT INTO public.users VALUES (1, 'wadih zouhari', 'wadih080881@gmail.com', '$2y$10$E1EqBzQuxSlmgF6Y/WH/wuA4E.77XLPqE8aNXMjCYua6Gtc2Xc2/W', 'bn304nFMrmPosrNcchPuE2KqdA6ffN4tNSZ2Pdm5HZhS63PplGIA0Gg7wD6e', '2019-07-03 02:37:17', '2019-07-03 02:37:17');
INSERT INTO public.users VALUES (10, 'rafael orecchio', 'rafaeldov@hotmail.com', '$2y$10$VeXx9VkDbmJVBP84w47X9eJfSzcoUup1jeMI0GNxIHPVXeaEvCYES', 'hqq0ruXXYoYMWt6TTRxINCj5iH2ozoxlszLkHuNloD3MseBkID6nwrUvT7Wm', '2019-07-31 13:47:07', '2019-07-31 13:47:07');
INSERT INTO public.users VALUES (11, 'jhon tovar', 'cadtovarj13@gmail.com', '$2y$10$QpUOl.s..qkS6JmGr9k9hOZ9fPi9Risvitn6j.p0fqtmVnXOdD65y', 'MUBd59zou7McYT4GkHBuWDrhr8KFycBgPbhypBLE9OdPGF7ZaHwt2u1VqGMr', '2019-07-31 13:48:25', '2019-07-31 13:48:25');
INSERT INTO public.users VALUES (12, 'anthony ordoñez', 'anthoni1994@gmail.com', '$2y$10$t8/DHnGgYvurIWeXAWpZaOQ/s4mo7ez6JEo8Oa5h7efsnmjtBzbFO', 'TOByVVyjScCGj9RlARRkW7d90AsonEDAQmHuEaIsNPHG8Y321Rb1PqX5cPhr', '2019-07-31 13:50:15', '2019-07-31 13:50:15');
INSERT INTO public.users VALUES (13, 'pablo adriazola', 'pablo.adriazola@outlook.com', '$2y$10$QQr4WI1IxROE6rfFhPngeuCTcSA415yqv.d3dFovUpXlX7UPFTXfC', 'ZojdzexYMBUkUUr37bAsr5e7ZGOnyjegdRQdmIaLnngJ8dlQCMC1WWBgGQSb', '2019-07-31 13:51:50', '2019-07-31 13:51:50');
INSERT INTO public.users VALUES (14, 'juan frontado', 'juanfrontado3@gmail.com', '$2y$10$Sxx5ifn.52Z4DcGmGo0p9eKSvWd5cqJWIJEuMkm.hazMm6quNgOFu', 'AJ2kZael2MrA1bVLGlfXcwNxqHTzd3nswXB4nkImgacekbQDVS4s03j52iIm', '2019-07-31 14:05:18', '2019-07-31 14:05:18');
INSERT INTO public.users VALUES (15, 'osnier martinez', 'osniermartinez@gmail.com', '$2y$10$U6zFNH9JD1lsOni2A/TDZ.gv.fgoPDXJFDEj5Hb8BlaKgGdH0jvey', 'K3nRGWgIeuU0inEEElQSVudxw7oUJkAsymOovav4SwsJfks0l1W7AAGXwzV6', '2019-07-31 14:06:16', '2019-07-31 14:06:16');
INSERT INTO public.users VALUES (16, 'carlos pino', 'cpinox02@gmail.com', '$2y$10$15Yugs6/vOCzvj5O5pw49.XwA2990tX1hYCU7Jb4Atgn3zv0oJChe', 'Yw8BR9SZO7HQOa60tACC486m2UL6c8GfeqrZxeACZdM860b1mQKoElksswNx', '2019-07-31 14:07:10', '2019-07-31 14:07:10');
INSERT INTO public.users VALUES (17, 'raul socorro', 'raulsocorro@gmail.com', '$2y$10$TCtXOQHqWnT4xzPlHJWp8.wp8gY7Fy90nrnMmEUqd3e897eIv0TWq', 'LgQDmuTkeNvx0CmgVPpOfVuC9cWxFrcLRZazx8GEkU6EFITjBVLuy8oTUO8V', '2019-07-31 14:08:33', '2019-07-31 14:08:33');
INSERT INTO public.users VALUES (18, 'johan rosales', 'vrosalesjohamm@gmail.com', '$2y$10$2x.lV1RXBNnRxvPB3XFsLupysgjF8H0k9A7mm48xy/XAIb3w5k8TG', 's5LWz7ziYvChyDJNN0Pr8ZJTr6Qk4vabG5aZnzf9xvnfHpk5cE2hqzQ0LhFo', '2019-07-31 14:12:07', '2019-07-31 14:12:07');
INSERT INTO public.users VALUES (19, 'kelvin astudillo', 'leskel417@hotmail.com', '$2y$10$2db10d4PqScDTAp9mG2n7uB6.c4NUfhsgb97ky28O92z/PHKr9nBO', 'aGtfE9LO9ldsGTD1imbMAHqvW1o0t90JuRBYAhJx4xoHmaBgXLijzEhADdhs', '2019-07-31 14:16:44', '2019-07-31 14:16:44');
INSERT INTO public.users VALUES (20, 'cesar andrade', 'cesarrosales27@outlook.com', '$2y$10$V8wqXwnrxiiCrRj9je7f5egn6VsMJJ6XdXudRxZff.jMt8I20b/Be', '7WGkAGu97Skw6QQgnEFxnPUZGOc3ztZcdf3W0HVZwUk24pdDYuSyG3phiseO', '2019-07-31 14:20:11', '2019-07-31 14:20:11');
INSERT INTO public.users VALUES (21, 'anthony tua', 'anthonytua@gmail.com', '$2y$10$o9F55Jd0LGBqQKPmqEsfTek2DTBLiHibxtKosDK7ojrhBDGOHlc9S', '2Ptf0KKhFITRuKqp586J73Tc7xWqGspEE8jbjZYMH3x2rDH9YeChyAKqIAHz', '2019-07-31 14:21:47', '2019-07-31 14:21:47');
INSERT INTO public.users VALUES (23, 'miguel hanoum', 'mhanoum22@gmail.com', '$2y$10$.g.AxLNEHkDHuCyljgbmOulAZ9K1ieroidx6AyaehCWg8dRHFQj3u', 'aII0hkCgkqQZYTMLQedM6iOO1zu1xUx8l6Ok82v3Om93w3OxhyXBExCypmzj', '2019-07-31 17:33:01', '2019-07-31 17:33:01');
INSERT INTO public.users VALUES (8, 'amanda rondon', 'amaluz14@gmail.com', '$2y$10$6iTT9lIKRdhue51urCt0suHlD77PjDRR46WC7JjRa09lna7RRZUCq', 'JCDl2QFHrtYFq0vLmltP5zDWAfBm8vHvOEc1nIkJZVBMNDbCOXsD830OCoFK', '2019-07-30 13:54:52', '2019-07-30 13:54:52');
INSERT INTO public.users VALUES (24, 'Jorge Lozano', 'Jorgelozano12@gmail.com', '$2y$10$dE9.fJcJdvl4cxWFPY01Xu5ngM6hVBoA.yc/n4ExrIn5X61oCsTUW', 'wMwXbaz4jlbPAjbPEzJerW9y49LZxwSNINpGjHlkrfhx4nLckHleLerxi1WZ', '2019-08-01 14:57:23', '2019-08-01 14:57:23');


--
-- TOC entry 3988 (class 0 OID 3312032)
-- Dependencies: 219
-- Data for Name: vuelos; Type: TABLE DATA; Schema: public; Owner: otjeadbwenlfkc
--

INSERT INTO public.vuelos VALUES (1, 4, 1, 3.50, '2019-07-12', 'monomotor', 0.00, 0.00, 0.00, 0.00, 'yv120e', '2019-07-12 14:33:45', '2019-07-12 14:33:45');
INSERT INTO public.vuelos VALUES (2, 4, 1, 3.70, '2019-07-30', 'monomotor', 0.00, 0.00, 0.00, 0.00, 'yv120e', '2019-07-30 13:45:48', '2019-07-30 13:45:48');
INSERT INTO public.vuelos VALUES (4, 4, 1, 2.80, '2019-07-30', 'monomotor', 0.00, 0.00, 0.00, 0.00, 'yv120e', '2019-07-30 13:49:45', '2019-07-30 13:49:45');
INSERT INTO public.vuelos VALUES (6, 4, 1, 6.80, '2019-07-30', 'instrumental', 0.00, 0.00, 0.00, 0.00, 'yv120e', '2019-07-30 14:09:11', '2019-07-30 14:09:11');
INSERT INTO public.vuelos VALUES (7, 4, 1, 5.00, '2019-07-30', 'monomotor', 0.00, 0.00, 0.00, 0.00, 'yv120e', '2019-07-30 14:10:51', '2019-07-30 14:10:51');
INSERT INTO public.vuelos VALUES (9, 11, 1, 66.10, '2019-03-27', 'monomotor', 0.00, 0.00, 0.00, 0.00, 'cessnna 0186', '2019-08-01 14:30:37', '2019-08-01 14:30:37');


--
-- TOC entry 4012 (class 0 OID 0)
-- Dependencies: 197
-- Name: compras_id_seq; Type: SEQUENCE SET; Schema: public; Owner: otjeadbwenlfkc
--

SELECT pg_catalog.setval('public.compras_id_seq', 9, true);


--
-- TOC entry 4013 (class 0 OID 0)
-- Dependencies: 199
-- Name: estudiantes_id_seq; Type: SEQUENCE SET; Schema: public; Owner: otjeadbwenlfkc
--

SELECT pg_catalog.setval('public.estudiantes_id_seq', 14, true);


--
-- TOC entry 4014 (class 0 OID 0)
-- Dependencies: 201
-- Name: instructors_id_seq; Type: SEQUENCE SET; Schema: public; Owner: otjeadbwenlfkc
--

SELECT pg_catalog.setval('public.instructors_id_seq', 2, true);


--
-- TOC entry 4015 (class 0 OID 0)
-- Dependencies: 203
-- Name: migrations_id_seq; Type: SEQUENCE SET; Schema: public; Owner: otjeadbwenlfkc
--

SELECT pg_catalog.setval('public.migrations_id_seq', 13, true);


--
-- TOC entry 4016 (class 0 OID 0)
-- Dependencies: 206
-- Name: permission_role_id_seq; Type: SEQUENCE SET; Schema: public; Owner: otjeadbwenlfkc
--

SELECT pg_catalog.setval('public.permission_role_id_seq', 21, true);


--
-- TOC entry 4017 (class 0 OID 0)
-- Dependencies: 208
-- Name: permission_user_id_seq; Type: SEQUENCE SET; Schema: public; Owner: otjeadbwenlfkc
--

SELECT pg_catalog.setval('public.permission_user_id_seq', 1, false);


--
-- TOC entry 4018 (class 0 OID 0)
-- Dependencies: 210
-- Name: permissions_id_seq; Type: SEQUENCE SET; Schema: public; Owner: otjeadbwenlfkc
--

SELECT pg_catalog.setval('public.permissions_id_seq', 30, true);


--
-- TOC entry 4019 (class 0 OID 0)
-- Dependencies: 212
-- Name: products_id_seq; Type: SEQUENCE SET; Schema: public; Owner: otjeadbwenlfkc
--

SELECT pg_catalog.setval('public.products_id_seq', 1, false);


--
-- TOC entry 4020 (class 0 OID 0)
-- Dependencies: 214
-- Name: role_user_id_seq; Type: SEQUENCE SET; Schema: public; Owner: otjeadbwenlfkc
--

SELECT pg_catalog.setval('public.role_user_id_seq', 8, true);


--
-- TOC entry 4021 (class 0 OID 0)
-- Dependencies: 216
-- Name: roles_id_seq; Type: SEQUENCE SET; Schema: public; Owner: otjeadbwenlfkc
--

SELECT pg_catalog.setval('public.roles_id_seq', 5, true);


--
-- TOC entry 4022 (class 0 OID 0)
-- Dependencies: 218
-- Name: users_id_seq; Type: SEQUENCE SET; Schema: public; Owner: otjeadbwenlfkc
--

SELECT pg_catalog.setval('public.users_id_seq', 24, true);


--
-- TOC entry 4023 (class 0 OID 0)
-- Dependencies: 220
-- Name: vuelos_id_seq; Type: SEQUENCE SET; Schema: public; Owner: otjeadbwenlfkc
--

SELECT pg_catalog.setval('public.vuelos_id_seq', 9, true);


--
-- TOC entry 3795 (class 2606 OID 3312050)
-- Name: compras compras_pkey; Type: CONSTRAINT; Schema: public; Owner: otjeadbwenlfkc
--

ALTER TABLE ONLY public.compras
    ADD CONSTRAINT compras_pkey PRIMARY KEY (id);


--
-- TOC entry 3797 (class 2606 OID 3312052)
-- Name: estudiantes estudiantes_pkey; Type: CONSTRAINT; Schema: public; Owner: otjeadbwenlfkc
--

ALTER TABLE ONLY public.estudiantes
    ADD CONSTRAINT estudiantes_pkey PRIMARY KEY (id);


--
-- TOC entry 3799 (class 2606 OID 3312054)
-- Name: instructors instructors_pkey; Type: CONSTRAINT; Schema: public; Owner: otjeadbwenlfkc
--

ALTER TABLE ONLY public.instructors
    ADD CONSTRAINT instructors_pkey PRIMARY KEY (id);


--
-- TOC entry 3801 (class 2606 OID 3312056)
-- Name: migrations migrations_pkey; Type: CONSTRAINT; Schema: public; Owner: otjeadbwenlfkc
--

ALTER TABLE ONLY public.migrations
    ADD CONSTRAINT migrations_pkey PRIMARY KEY (id);


--
-- TOC entry 3805 (class 2606 OID 3312058)
-- Name: permission_role permission_role_pkey; Type: CONSTRAINT; Schema: public; Owner: otjeadbwenlfkc
--

ALTER TABLE ONLY public.permission_role
    ADD CONSTRAINT permission_role_pkey PRIMARY KEY (id);


--
-- TOC entry 3809 (class 2606 OID 3312060)
-- Name: permission_user permission_user_pkey; Type: CONSTRAINT; Schema: public; Owner: otjeadbwenlfkc
--

ALTER TABLE ONLY public.permission_user
    ADD CONSTRAINT permission_user_pkey PRIMARY KEY (id);


--
-- TOC entry 3812 (class 2606 OID 3312062)
-- Name: permissions permissions_pkey; Type: CONSTRAINT; Schema: public; Owner: otjeadbwenlfkc
--

ALTER TABLE ONLY public.permissions
    ADD CONSTRAINT permissions_pkey PRIMARY KEY (id);


--
-- TOC entry 3814 (class 2606 OID 3312064)
-- Name: permissions permissions_slug_unique; Type: CONSTRAINT; Schema: public; Owner: otjeadbwenlfkc
--

ALTER TABLE ONLY public.permissions
    ADD CONSTRAINT permissions_slug_unique UNIQUE (slug);


--
-- TOC entry 3816 (class 2606 OID 3312066)
-- Name: products products_pkey; Type: CONSTRAINT; Schema: public; Owner: otjeadbwenlfkc
--

ALTER TABLE ONLY public.products
    ADD CONSTRAINT products_pkey PRIMARY KEY (id);


--
-- TOC entry 3818 (class 2606 OID 3312068)
-- Name: role_user role_user_pkey; Type: CONSTRAINT; Schema: public; Owner: otjeadbwenlfkc
--

ALTER TABLE ONLY public.role_user
    ADD CONSTRAINT role_user_pkey PRIMARY KEY (id);


--
-- TOC entry 3822 (class 2606 OID 3312070)
-- Name: roles roles_name_unique; Type: CONSTRAINT; Schema: public; Owner: otjeadbwenlfkc
--

ALTER TABLE ONLY public.roles
    ADD CONSTRAINT roles_name_unique UNIQUE (name);


--
-- TOC entry 3824 (class 2606 OID 3312072)
-- Name: roles roles_pkey; Type: CONSTRAINT; Schema: public; Owner: otjeadbwenlfkc
--

ALTER TABLE ONLY public.roles
    ADD CONSTRAINT roles_pkey PRIMARY KEY (id);


--
-- TOC entry 3826 (class 2606 OID 3312074)
-- Name: roles roles_slug_unique; Type: CONSTRAINT; Schema: public; Owner: otjeadbwenlfkc
--

ALTER TABLE ONLY public.roles
    ADD CONSTRAINT roles_slug_unique UNIQUE (slug);


--
-- TOC entry 3828 (class 2606 OID 3312076)
-- Name: users users_email_unique; Type: CONSTRAINT; Schema: public; Owner: otjeadbwenlfkc
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_email_unique UNIQUE (email);


--
-- TOC entry 3830 (class 2606 OID 3312078)
-- Name: users users_pkey; Type: CONSTRAINT; Schema: public; Owner: otjeadbwenlfkc
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (id);


--
-- TOC entry 3832 (class 2606 OID 3312080)
-- Name: vuelos vuelos_pkey; Type: CONSTRAINT; Schema: public; Owner: otjeadbwenlfkc
--

ALTER TABLE ONLY public.vuelos
    ADD CONSTRAINT vuelos_pkey PRIMARY KEY (id);


--
-- TOC entry 3802 (class 1259 OID 3312081)
-- Name: password_resets_email_index; Type: INDEX; Schema: public; Owner: otjeadbwenlfkc
--

CREATE INDEX password_resets_email_index ON public.password_resets USING btree (email);


--
-- TOC entry 3803 (class 1259 OID 3312082)
-- Name: permission_role_permission_id_index; Type: INDEX; Schema: public; Owner: otjeadbwenlfkc
--

CREATE INDEX permission_role_permission_id_index ON public.permission_role USING btree (permission_id);


--
-- TOC entry 3806 (class 1259 OID 3312083)
-- Name: permission_role_role_id_index; Type: INDEX; Schema: public; Owner: otjeadbwenlfkc
--

CREATE INDEX permission_role_role_id_index ON public.permission_role USING btree (role_id);


--
-- TOC entry 3807 (class 1259 OID 3312084)
-- Name: permission_user_permission_id_index; Type: INDEX; Schema: public; Owner: otjeadbwenlfkc
--

CREATE INDEX permission_user_permission_id_index ON public.permission_user USING btree (permission_id);


--
-- TOC entry 3810 (class 1259 OID 3312085)
-- Name: permission_user_user_id_index; Type: INDEX; Schema: public; Owner: otjeadbwenlfkc
--

CREATE INDEX permission_user_user_id_index ON public.permission_user USING btree (user_id);


--
-- TOC entry 3819 (class 1259 OID 3312086)
-- Name: role_user_role_id_index; Type: INDEX; Schema: public; Owner: otjeadbwenlfkc
--

CREATE INDEX role_user_role_id_index ON public.role_user USING btree (role_id);


--
-- TOC entry 3820 (class 1259 OID 3312087)
-- Name: role_user_user_id_index; Type: INDEX; Schema: public; Owner: otjeadbwenlfkc
--

CREATE INDEX role_user_user_id_index ON public.role_user USING btree (user_id);


--
-- TOC entry 3833 (class 2606 OID 3312088)
-- Name: compras compras_user_id_foreign; Type: FK CONSTRAINT; Schema: public; Owner: otjeadbwenlfkc
--

ALTER TABLE ONLY public.compras
    ADD CONSTRAINT compras_user_id_foreign FOREIGN KEY (user_id) REFERENCES public.users(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3834 (class 2606 OID 3312093)
-- Name: estudiantes estudiantes_user_id_foreign; Type: FK CONSTRAINT; Schema: public; Owner: otjeadbwenlfkc
--

ALTER TABLE ONLY public.estudiantes
    ADD CONSTRAINT estudiantes_user_id_foreign FOREIGN KEY (user_id) REFERENCES public.users(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3835 (class 2606 OID 3312098)
-- Name: instructors instructors_user_id_foreign; Type: FK CONSTRAINT; Schema: public; Owner: otjeadbwenlfkc
--

ALTER TABLE ONLY public.instructors
    ADD CONSTRAINT instructors_user_id_foreign FOREIGN KEY (user_id) REFERENCES public.users(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3836 (class 2606 OID 3312103)
-- Name: permission_role permission_role_permission_id_foreign; Type: FK CONSTRAINT; Schema: public; Owner: otjeadbwenlfkc
--

ALTER TABLE ONLY public.permission_role
    ADD CONSTRAINT permission_role_permission_id_foreign FOREIGN KEY (permission_id) REFERENCES public.permissions(id) ON DELETE CASCADE;


--
-- TOC entry 3837 (class 2606 OID 3312108)
-- Name: permission_role permission_role_role_id_foreign; Type: FK CONSTRAINT; Schema: public; Owner: otjeadbwenlfkc
--

ALTER TABLE ONLY public.permission_role
    ADD CONSTRAINT permission_role_role_id_foreign FOREIGN KEY (role_id) REFERENCES public.roles(id) ON DELETE CASCADE;


--
-- TOC entry 3838 (class 2606 OID 3312113)
-- Name: permission_user permission_user_permission_id_foreign; Type: FK CONSTRAINT; Schema: public; Owner: otjeadbwenlfkc
--

ALTER TABLE ONLY public.permission_user
    ADD CONSTRAINT permission_user_permission_id_foreign FOREIGN KEY (permission_id) REFERENCES public.permissions(id) ON DELETE CASCADE;


--
-- TOC entry 3839 (class 2606 OID 3312118)
-- Name: permission_user permission_user_user_id_foreign; Type: FK CONSTRAINT; Schema: public; Owner: otjeadbwenlfkc
--

ALTER TABLE ONLY public.permission_user
    ADD CONSTRAINT permission_user_user_id_foreign FOREIGN KEY (user_id) REFERENCES public.users(id) ON DELETE CASCADE;


--
-- TOC entry 3840 (class 2606 OID 3312123)
-- Name: role_user role_user_role_id_foreign; Type: FK CONSTRAINT; Schema: public; Owner: otjeadbwenlfkc
--

ALTER TABLE ONLY public.role_user
    ADD CONSTRAINT role_user_role_id_foreign FOREIGN KEY (role_id) REFERENCES public.roles(id) ON DELETE CASCADE;


--
-- TOC entry 3841 (class 2606 OID 3312128)
-- Name: role_user role_user_user_id_foreign; Type: FK CONSTRAINT; Schema: public; Owner: otjeadbwenlfkc
--

ALTER TABLE ONLY public.role_user
    ADD CONSTRAINT role_user_user_id_foreign FOREIGN KEY (user_id) REFERENCES public.users(id) ON DELETE CASCADE;


--
-- TOC entry 3842 (class 2606 OID 3312133)
-- Name: vuelos vuelos_id_estudiante_foreign; Type: FK CONSTRAINT; Schema: public; Owner: otjeadbwenlfkc
--

ALTER TABLE ONLY public.vuelos
    ADD CONSTRAINT vuelos_id_estudiante_foreign FOREIGN KEY (id_estudiante) REFERENCES public.estudiantes(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3843 (class 2606 OID 3312138)
-- Name: vuelos vuelos_id_instructor_foreign; Type: FK CONSTRAINT; Schema: public; Owner: otjeadbwenlfkc
--

ALTER TABLE ONLY public.vuelos
    ADD CONSTRAINT vuelos_id_instructor_foreign FOREIGN KEY (id_instructor) REFERENCES public.instructors(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3996 (class 0 OID 0)
-- Dependencies: 3995
-- Name: DATABASE d3d1kqf4bqnar8; Type: ACL; Schema: -; Owner: otjeadbwenlfkc
--

REVOKE CONNECT,TEMPORARY ON DATABASE d3d1kqf4bqnar8 FROM PUBLIC;


--
-- TOC entry 3998 (class 0 OID 0)
-- Dependencies: 3
-- Name: SCHEMA public; Type: ACL; Schema: -; Owner: otjeadbwenlfkc
--

REVOKE ALL ON SCHEMA public FROM postgres;
REVOKE ALL ON SCHEMA public FROM PUBLIC;
GRANT ALL ON SCHEMA public TO otjeadbwenlfkc;
GRANT ALL ON SCHEMA public TO PUBLIC;


--
-- TOC entry 3999 (class 0 OID 0)
-- Dependencies: 668
-- Name: LANGUAGE plpgsql; Type: ACL; Schema: -; Owner: postgres
--

GRANT ALL ON LANGUAGE plpgsql TO otjeadbwenlfkc;


-- Completed on 2019-08-13 09:48:01

--
-- PostgreSQL database dump complete
--

