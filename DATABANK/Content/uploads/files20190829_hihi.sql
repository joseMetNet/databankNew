PGDMP     ;        
            w            d3d1kqf4bqnar8     11.5 (Ubuntu 11.5-1.pgdg16.04+1)    11.4 q    �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                       false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                       false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                       false            �           1262    3311459    d3d1kqf4bqnar8    DATABASE     �   CREATE DATABASE d3d1kqf4bqnar8 WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'en_US.UTF-8' LC_CTYPE = 'en_US.UTF-8';
    DROP DATABASE d3d1kqf4bqnar8;
             otjeadbwenlfkc    false                        2615    2200    public    SCHEMA        CREATE SCHEMA public;
    DROP SCHEMA public;
             otjeadbwenlfkc    false            �            1259    3311955    compras    TABLE     !  CREATE TABLE public.compras (
    id integer NOT NULL,
    user_id integer NOT NULL,
    horas_compradas numeric(8,2) NOT NULL,
    fecha_compra date NOT NULL,
    monto numeric(8,2) NOT NULL,
    created_at timestamp(0) without time zone,
    updated_at timestamp(0) without time zone
);
    DROP TABLE public.compras;
       public         otjeadbwenlfkc    false    3            �            1259    3311958    compras_id_seq    SEQUENCE     �   CREATE SEQUENCE public.compras_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 %   DROP SEQUENCE public.compras_id_seq;
       public       otjeadbwenlfkc    false    196    3            �           0    0    compras_id_seq    SEQUENCE OWNED BY     A   ALTER SEQUENCE public.compras_id_seq OWNED BY public.compras.id;
            public       otjeadbwenlfkc    false    197            �            1259    3311960    estudiantes    TABLE     	  CREATE TABLE public.estudiantes (
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
    DROP TABLE public.estudiantes;
       public         otjeadbwenlfkc    false    3            �            1259    3311969    estudiantes_id_seq    SEQUENCE     �   CREATE SEQUENCE public.estudiantes_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 )   DROP SEQUENCE public.estudiantes_id_seq;
       public       otjeadbwenlfkc    false    198    3            �           0    0    estudiantes_id_seq    SEQUENCE OWNED BY     I   ALTER SEQUENCE public.estudiantes_id_seq OWNED BY public.estudiantes.id;
            public       otjeadbwenlfkc    false    199            �            1259    3311971    instructors    TABLE     	  CREATE TABLE public.instructors (
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
    DROP TABLE public.instructors;
       public         otjeadbwenlfkc    false    3            �            1259    3311980    instructors_id_seq    SEQUENCE     �   CREATE SEQUENCE public.instructors_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 )   DROP SEQUENCE public.instructors_id_seq;
       public       otjeadbwenlfkc    false    200    3            �           0    0    instructors_id_seq    SEQUENCE OWNED BY     I   ALTER SEQUENCE public.instructors_id_seq OWNED BY public.instructors.id;
            public       otjeadbwenlfkc    false    201            �            1259    3311982 
   migrations    TABLE     �   CREATE TABLE public.migrations (
    id integer NOT NULL,
    migration character varying(120) NOT NULL,
    batch integer NOT NULL
);
    DROP TABLE public.migrations;
       public         otjeadbwenlfkc    false    3            �            1259    3311985    migrations_id_seq    SEQUENCE     �   CREATE SEQUENCE public.migrations_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 (   DROP SEQUENCE public.migrations_id_seq;
       public       otjeadbwenlfkc    false    3    202            �           0    0    migrations_id_seq    SEQUENCE OWNED BY     G   ALTER SEQUENCE public.migrations_id_seq OWNED BY public.migrations.id;
            public       otjeadbwenlfkc    false    203            �            1259    3311987    password_resets    TABLE     �   CREATE TABLE public.password_resets (
    email character varying(120) NOT NULL,
    token character varying(120) NOT NULL,
    created_at timestamp(0) without time zone
);
 #   DROP TABLE public.password_resets;
       public         otjeadbwenlfkc    false    3            �            1259    3311990    permission_role    TABLE     �   CREATE TABLE public.permission_role (
    id integer NOT NULL,
    permission_id integer NOT NULL,
    role_id integer NOT NULL,
    created_at timestamp(0) without time zone,
    updated_at timestamp(0) without time zone
);
 #   DROP TABLE public.permission_role;
       public         otjeadbwenlfkc    false    3            �            1259    3311993    permission_role_id_seq    SEQUENCE     �   CREATE SEQUENCE public.permission_role_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 -   DROP SEQUENCE public.permission_role_id_seq;
       public       otjeadbwenlfkc    false    205    3            �           0    0    permission_role_id_seq    SEQUENCE OWNED BY     Q   ALTER SEQUENCE public.permission_role_id_seq OWNED BY public.permission_role.id;
            public       otjeadbwenlfkc    false    206            �            1259    3311995    permission_user    TABLE     �   CREATE TABLE public.permission_user (
    id integer NOT NULL,
    permission_id integer NOT NULL,
    user_id integer NOT NULL,
    created_at timestamp(0) without time zone,
    updated_at timestamp(0) without time zone
);
 #   DROP TABLE public.permission_user;
       public         otjeadbwenlfkc    false    3            �            1259    3311998    permission_user_id_seq    SEQUENCE     �   CREATE SEQUENCE public.permission_user_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 -   DROP SEQUENCE public.permission_user_id_seq;
       public       otjeadbwenlfkc    false    207    3            �           0    0    permission_user_id_seq    SEQUENCE OWNED BY     Q   ALTER SEQUENCE public.permission_user_id_seq OWNED BY public.permission_user.id;
            public       otjeadbwenlfkc    false    208            �            1259    3312000    permissions    TABLE       CREATE TABLE public.permissions (
    id integer NOT NULL,
    name character varying(120) NOT NULL,
    slug character varying(120) NOT NULL,
    description text,
    created_at timestamp(0) without time zone,
    updated_at timestamp(0) without time zone
);
    DROP TABLE public.permissions;
       public         otjeadbwenlfkc    false    3            �            1259    3312006    permissions_id_seq    SEQUENCE     �   CREATE SEQUENCE public.permissions_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 )   DROP SEQUENCE public.permissions_id_seq;
       public       otjeadbwenlfkc    false    3    209            �           0    0    permissions_id_seq    SEQUENCE OWNED BY     I   ALTER SEQUENCE public.permissions_id_seq OWNED BY public.permissions.id;
            public       otjeadbwenlfkc    false    210            �            1259    3312008    products    TABLE     �   CREATE TABLE public.products (
    id integer NOT NULL,
    name character varying(120) NOT NULL,
    description character varying(120) NOT NULL,
    created_at timestamp(0) without time zone,
    updated_at timestamp(0) without time zone
);
    DROP TABLE public.products;
       public         otjeadbwenlfkc    false    3            �            1259    3312011    products_id_seq    SEQUENCE     �   CREATE SEQUENCE public.products_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 &   DROP SEQUENCE public.products_id_seq;
       public       otjeadbwenlfkc    false    211    3            �           0    0    products_id_seq    SEQUENCE OWNED BY     C   ALTER SEQUENCE public.products_id_seq OWNED BY public.products.id;
            public       otjeadbwenlfkc    false    212            �            1259    3312013 	   role_user    TABLE     �   CREATE TABLE public.role_user (
    id integer NOT NULL,
    role_id integer NOT NULL,
    user_id integer NOT NULL,
    created_at timestamp(0) without time zone,
    updated_at timestamp(0) without time zone
);
    DROP TABLE public.role_user;
       public         otjeadbwenlfkc    false    3            �            1259    3312016    role_user_id_seq    SEQUENCE     �   CREATE SEQUENCE public.role_user_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 '   DROP SEQUENCE public.role_user_id_seq;
       public       otjeadbwenlfkc    false    3    213            �           0    0    role_user_id_seq    SEQUENCE OWNED BY     E   ALTER SEQUENCE public.role_user_id_seq OWNED BY public.role_user.id;
            public       otjeadbwenlfkc    false    214            �            1259    3312018    roles    TABLE     �  CREATE TABLE public.roles (
    id integer NOT NULL,
    name character varying(120) NOT NULL,
    slug character varying(120) NOT NULL,
    description text,
    created_at timestamp(0) without time zone,
    updated_at timestamp(0) without time zone,
    special character varying(255),
    CONSTRAINT roles_special_check CHECK (((special)::text = ANY (ARRAY[('all-access'::character varying)::text, ('no-access'::character varying)::text])))
);
    DROP TABLE public.roles;
       public         otjeadbwenlfkc    false    3            �            1259    3312025    roles_id_seq    SEQUENCE     �   CREATE SEQUENCE public.roles_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 #   DROP SEQUENCE public.roles_id_seq;
       public       otjeadbwenlfkc    false    3    215            �           0    0    roles_id_seq    SEQUENCE OWNED BY     =   ALTER SEQUENCE public.roles_id_seq OWNED BY public.roles.id;
            public       otjeadbwenlfkc    false    216            �            1259    3312027    users    TABLE     C  CREATE TABLE public.users (
    id integer NOT NULL,
    name character varying(120) NOT NULL,
    email character varying(120) NOT NULL,
    password character varying(120) NOT NULL,
    remember_token character varying(100),
    created_at timestamp(0) without time zone,
    updated_at timestamp(0) without time zone
);
    DROP TABLE public.users;
       public         otjeadbwenlfkc    false    3            �            1259    3312030    users_id_seq    SEQUENCE     �   CREATE SEQUENCE public.users_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 #   DROP SEQUENCE public.users_id_seq;
       public       otjeadbwenlfkc    false    3    217            �           0    0    users_id_seq    SEQUENCE OWNED BY     =   ALTER SEQUENCE public.users_id_seq OWNED BY public.users.id;
            public       otjeadbwenlfkc    false    218            �            1259    3312032    vuelos    TABLE     "  CREATE TABLE public.vuelos (
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
    DROP TABLE public.vuelos;
       public         otjeadbwenlfkc    false    3            �            1259    3312035    vuelos_id_seq    SEQUENCE     �   CREATE SEQUENCE public.vuelos_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 $   DROP SEQUENCE public.vuelos_id_seq;
       public       otjeadbwenlfkc    false    3    219            �           0    0    vuelos_id_seq    SEQUENCE OWNED BY     ?   ALTER SEQUENCE public.vuelos_id_seq OWNED BY public.vuelos.id;
            public       otjeadbwenlfkc    false    220            �           2604    3312037 
   compras id    DEFAULT     h   ALTER TABLE ONLY public.compras ALTER COLUMN id SET DEFAULT nextval('public.compras_id_seq'::regclass);
 9   ALTER TABLE public.compras ALTER COLUMN id DROP DEFAULT;
       public       otjeadbwenlfkc    false    197    196            �           2604    3312038    estudiantes id    DEFAULT     p   ALTER TABLE ONLY public.estudiantes ALTER COLUMN id SET DEFAULT nextval('public.estudiantes_id_seq'::regclass);
 =   ALTER TABLE public.estudiantes ALTER COLUMN id DROP DEFAULT;
       public       otjeadbwenlfkc    false    199    198            �           2604    3312039    instructors id    DEFAULT     p   ALTER TABLE ONLY public.instructors ALTER COLUMN id SET DEFAULT nextval('public.instructors_id_seq'::regclass);
 =   ALTER TABLE public.instructors ALTER COLUMN id DROP DEFAULT;
       public       otjeadbwenlfkc    false    201    200            �           2604    3312040    migrations id    DEFAULT     n   ALTER TABLE ONLY public.migrations ALTER COLUMN id SET DEFAULT nextval('public.migrations_id_seq'::regclass);
 <   ALTER TABLE public.migrations ALTER COLUMN id DROP DEFAULT;
       public       otjeadbwenlfkc    false    203    202            �           2604    3312041    permission_role id    DEFAULT     x   ALTER TABLE ONLY public.permission_role ALTER COLUMN id SET DEFAULT nextval('public.permission_role_id_seq'::regclass);
 A   ALTER TABLE public.permission_role ALTER COLUMN id DROP DEFAULT;
       public       otjeadbwenlfkc    false    206    205            �           2604    3312042    permission_user id    DEFAULT     x   ALTER TABLE ONLY public.permission_user ALTER COLUMN id SET DEFAULT nextval('public.permission_user_id_seq'::regclass);
 A   ALTER TABLE public.permission_user ALTER COLUMN id DROP DEFAULT;
       public       otjeadbwenlfkc    false    208    207            �           2604    3312043    permissions id    DEFAULT     p   ALTER TABLE ONLY public.permissions ALTER COLUMN id SET DEFAULT nextval('public.permissions_id_seq'::regclass);
 =   ALTER TABLE public.permissions ALTER COLUMN id DROP DEFAULT;
       public       otjeadbwenlfkc    false    210    209            �           2604    3312044    products id    DEFAULT     j   ALTER TABLE ONLY public.products ALTER COLUMN id SET DEFAULT nextval('public.products_id_seq'::regclass);
 :   ALTER TABLE public.products ALTER COLUMN id DROP DEFAULT;
       public       otjeadbwenlfkc    false    212    211            �           2604    3312045    role_user id    DEFAULT     l   ALTER TABLE ONLY public.role_user ALTER COLUMN id SET DEFAULT nextval('public.role_user_id_seq'::regclass);
 ;   ALTER TABLE public.role_user ALTER COLUMN id DROP DEFAULT;
       public       otjeadbwenlfkc    false    214    213            �           2604    3312046    roles id    DEFAULT     d   ALTER TABLE ONLY public.roles ALTER COLUMN id SET DEFAULT nextval('public.roles_id_seq'::regclass);
 7   ALTER TABLE public.roles ALTER COLUMN id DROP DEFAULT;
       public       otjeadbwenlfkc    false    216    215            �           2604    3312047    users id    DEFAULT     d   ALTER TABLE ONLY public.users ALTER COLUMN id SET DEFAULT nextval('public.users_id_seq'::regclass);
 7   ALTER TABLE public.users ALTER COLUMN id DROP DEFAULT;
       public       otjeadbwenlfkc    false    218    217            �           2604    3312048 	   vuelos id    DEFAULT     f   ALTER TABLE ONLY public.vuelos ALTER COLUMN id SET DEFAULT nextval('public.vuelos_id_seq'::regclass);
 8   ALTER TABLE public.vuelos ALTER COLUMN id DROP DEFAULT;
       public       otjeadbwenlfkc    false    220    219            }          0    3311955    compras 
   TABLE DATA               l   COPY public.compras (id, user_id, horas_compradas, fecha_compra, monto, created_at, updated_at) FROM stdin;
    public       otjeadbwenlfkc    false    196   >�                 0    3311960    estudiantes 
   TABLE DATA               �  COPY public.estudiantes (id, user_id, nombre, apellido, cedula, pasaporte, f_nacimiento, peso, estatura, sexo, grupo_sangre, direccion, estado, municipio, ciudad, codigo_postal, tlf_local, tlf_movil, correo, nombre_emerg, tlf1_emerg, tlf2_emerg, tlf3_emerg, tipo_licencia, vence_certificado, vence_licencia, horas_externas, evaluacion_medica, hab_instrumental, hab_monomotor, hab_multimotor, horas_pic, horas_sic, created_at, updated_at) FROM stdin;
    public       otjeadbwenlfkc    false    198   �       �          0    3311971    instructors 
   TABLE DATA               �  COPY public.instructors (id, user_id, nombre, apellido, cedula, pasaporte, f_nacimiento, peso, estatura, sexo, grupo_sangre, direccion, estado, municipio, ciudad, codigo_postal, tlf_local, tlf_movil, correo, nombre_emerg, tlf1_emerg, tlf2_emerg, tlf3_emerg, tipo_licencia, vence_certificado, vence_licencia, horas_externas, evaluacion_medica, hab_instrumental, hab_monomotor, hab_multimotor, horas_pic, horas_sic, created_at, updated_at) FROM stdin;
    public       otjeadbwenlfkc    false    200   X�       �          0    3311982 
   migrations 
   TABLE DATA               :   COPY public.migrations (id, migration, batch) FROM stdin;
    public       otjeadbwenlfkc    false    202   ��       �          0    3311987    password_resets 
   TABLE DATA               C   COPY public.password_resets (email, token, created_at) FROM stdin;
    public       otjeadbwenlfkc    false    204   ��       �          0    3311990    permission_role 
   TABLE DATA               ]   COPY public.permission_role (id, permission_id, role_id, created_at, updated_at) FROM stdin;
    public       otjeadbwenlfkc    false    205   +�       �          0    3311995    permission_user 
   TABLE DATA               ]   COPY public.permission_user (id, permission_id, user_id, created_at, updated_at) FROM stdin;
    public       otjeadbwenlfkc    false    207   ��       �          0    3312000    permissions 
   TABLE DATA               Z   COPY public.permissions (id, name, slug, description, created_at, updated_at) FROM stdin;
    public       otjeadbwenlfkc    false    209   ם       �          0    3312008    products 
   TABLE DATA               Q   COPY public.products (id, name, description, created_at, updated_at) FROM stdin;
    public       otjeadbwenlfkc    false    211   ,�       �          0    3312013 	   role_user 
   TABLE DATA               Q   COPY public.role_user (id, role_id, user_id, created_at, updated_at) FROM stdin;
    public       otjeadbwenlfkc    false    213   I�       �          0    3312018    roles 
   TABLE DATA               ]   COPY public.roles (id, name, slug, description, created_at, updated_at, special) FROM stdin;
    public       otjeadbwenlfkc    false    215   ��       �          0    3312027    users 
   TABLE DATA               b   COPY public.users (id, name, email, password, remember_token, created_at, updated_at) FROM stdin;
    public       otjeadbwenlfkc    false    217   F�       �          0    3312032    vuelos 
   TABLE DATA               �   COPY public.vuelos (id, id_estudiante, id_instructor, horas_voladas, fecha_vuelo, modalidad, horas_helice, horas_aceite, horas_fuselaje, horas_bujias, avion, created_at, updated_at) FROM stdin;
    public       otjeadbwenlfkc    false    219   I�       �           0    0    compras_id_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('public.compras_id_seq', 9, true);
            public       otjeadbwenlfkc    false    197            �           0    0    estudiantes_id_seq    SEQUENCE SET     A   SELECT pg_catalog.setval('public.estudiantes_id_seq', 14, true);
            public       otjeadbwenlfkc    false    199            �           0    0    instructors_id_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('public.instructors_id_seq', 2, true);
            public       otjeadbwenlfkc    false    201            �           0    0    migrations_id_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('public.migrations_id_seq', 13, true);
            public       otjeadbwenlfkc    false    203            �           0    0    permission_role_id_seq    SEQUENCE SET     E   SELECT pg_catalog.setval('public.permission_role_id_seq', 21, true);
            public       otjeadbwenlfkc    false    206            �           0    0    permission_user_id_seq    SEQUENCE SET     E   SELECT pg_catalog.setval('public.permission_user_id_seq', 1, false);
            public       otjeadbwenlfkc    false    208            �           0    0    permissions_id_seq    SEQUENCE SET     A   SELECT pg_catalog.setval('public.permissions_id_seq', 30, true);
            public       otjeadbwenlfkc    false    210            �           0    0    products_id_seq    SEQUENCE SET     >   SELECT pg_catalog.setval('public.products_id_seq', 1, false);
            public       otjeadbwenlfkc    false    212            �           0    0    role_user_id_seq    SEQUENCE SET     >   SELECT pg_catalog.setval('public.role_user_id_seq', 8, true);
            public       otjeadbwenlfkc    false    214            �           0    0    roles_id_seq    SEQUENCE SET     :   SELECT pg_catalog.setval('public.roles_id_seq', 5, true);
            public       otjeadbwenlfkc    false    216            �           0    0    users_id_seq    SEQUENCE SET     ;   SELECT pg_catalog.setval('public.users_id_seq', 24, true);
            public       otjeadbwenlfkc    false    218            �           0    0    vuelos_id_seq    SEQUENCE SET     ;   SELECT pg_catalog.setval('public.vuelos_id_seq', 9, true);
            public       otjeadbwenlfkc    false    220            �           2606    3312050    compras compras_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public.compras
    ADD CONSTRAINT compras_pkey PRIMARY KEY (id);
 >   ALTER TABLE ONLY public.compras DROP CONSTRAINT compras_pkey;
       public         otjeadbwenlfkc    false    196            �           2606    3312052    estudiantes estudiantes_pkey 
   CONSTRAINT     Z   ALTER TABLE ONLY public.estudiantes
    ADD CONSTRAINT estudiantes_pkey PRIMARY KEY (id);
 F   ALTER TABLE ONLY public.estudiantes DROP CONSTRAINT estudiantes_pkey;
       public         otjeadbwenlfkc    false    198            �           2606    3312054    instructors instructors_pkey 
   CONSTRAINT     Z   ALTER TABLE ONLY public.instructors
    ADD CONSTRAINT instructors_pkey PRIMARY KEY (id);
 F   ALTER TABLE ONLY public.instructors DROP CONSTRAINT instructors_pkey;
       public         otjeadbwenlfkc    false    200            �           2606    3312056    migrations migrations_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public.migrations
    ADD CONSTRAINT migrations_pkey PRIMARY KEY (id);
 D   ALTER TABLE ONLY public.migrations DROP CONSTRAINT migrations_pkey;
       public         otjeadbwenlfkc    false    202            �           2606    3312058 $   permission_role permission_role_pkey 
   CONSTRAINT     b   ALTER TABLE ONLY public.permission_role
    ADD CONSTRAINT permission_role_pkey PRIMARY KEY (id);
 N   ALTER TABLE ONLY public.permission_role DROP CONSTRAINT permission_role_pkey;
       public         otjeadbwenlfkc    false    205            �           2606    3312060 $   permission_user permission_user_pkey 
   CONSTRAINT     b   ALTER TABLE ONLY public.permission_user
    ADD CONSTRAINT permission_user_pkey PRIMARY KEY (id);
 N   ALTER TABLE ONLY public.permission_user DROP CONSTRAINT permission_user_pkey;
       public         otjeadbwenlfkc    false    207            �           2606    3312062    permissions permissions_pkey 
   CONSTRAINT     Z   ALTER TABLE ONLY public.permissions
    ADD CONSTRAINT permissions_pkey PRIMARY KEY (id);
 F   ALTER TABLE ONLY public.permissions DROP CONSTRAINT permissions_pkey;
       public         otjeadbwenlfkc    false    209            �           2606    3312064 #   permissions permissions_slug_unique 
   CONSTRAINT     ^   ALTER TABLE ONLY public.permissions
    ADD CONSTRAINT permissions_slug_unique UNIQUE (slug);
 M   ALTER TABLE ONLY public.permissions DROP CONSTRAINT permissions_slug_unique;
       public         otjeadbwenlfkc    false    209            �           2606    3312066    products products_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public.products
    ADD CONSTRAINT products_pkey PRIMARY KEY (id);
 @   ALTER TABLE ONLY public.products DROP CONSTRAINT products_pkey;
       public         otjeadbwenlfkc    false    211            �           2606    3312068    role_user role_user_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public.role_user
    ADD CONSTRAINT role_user_pkey PRIMARY KEY (id);
 B   ALTER TABLE ONLY public.role_user DROP CONSTRAINT role_user_pkey;
       public         otjeadbwenlfkc    false    213            �           2606    3312070    roles roles_name_unique 
   CONSTRAINT     R   ALTER TABLE ONLY public.roles
    ADD CONSTRAINT roles_name_unique UNIQUE (name);
 A   ALTER TABLE ONLY public.roles DROP CONSTRAINT roles_name_unique;
       public         otjeadbwenlfkc    false    215            �           2606    3312072    roles roles_pkey 
   CONSTRAINT     N   ALTER TABLE ONLY public.roles
    ADD CONSTRAINT roles_pkey PRIMARY KEY (id);
 :   ALTER TABLE ONLY public.roles DROP CONSTRAINT roles_pkey;
       public         otjeadbwenlfkc    false    215            �           2606    3312074    roles roles_slug_unique 
   CONSTRAINT     R   ALTER TABLE ONLY public.roles
    ADD CONSTRAINT roles_slug_unique UNIQUE (slug);
 A   ALTER TABLE ONLY public.roles DROP CONSTRAINT roles_slug_unique;
       public         otjeadbwenlfkc    false    215            �           2606    3312076    users users_email_unique 
   CONSTRAINT     T   ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_email_unique UNIQUE (email);
 B   ALTER TABLE ONLY public.users DROP CONSTRAINT users_email_unique;
       public         otjeadbwenlfkc    false    217            �           2606    3312078    users users_pkey 
   CONSTRAINT     N   ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (id);
 :   ALTER TABLE ONLY public.users DROP CONSTRAINT users_pkey;
       public         otjeadbwenlfkc    false    217            �           2606    3312080    vuelos vuelos_pkey 
   CONSTRAINT     P   ALTER TABLE ONLY public.vuelos
    ADD CONSTRAINT vuelos_pkey PRIMARY KEY (id);
 <   ALTER TABLE ONLY public.vuelos DROP CONSTRAINT vuelos_pkey;
       public         otjeadbwenlfkc    false    219            �           1259    3312081    password_resets_email_index    INDEX     X   CREATE INDEX password_resets_email_index ON public.password_resets USING btree (email);
 /   DROP INDEX public.password_resets_email_index;
       public         otjeadbwenlfkc    false    204            �           1259    3312082 #   permission_role_permission_id_index    INDEX     h   CREATE INDEX permission_role_permission_id_index ON public.permission_role USING btree (permission_id);
 7   DROP INDEX public.permission_role_permission_id_index;
       public         otjeadbwenlfkc    false    205            �           1259    3312083    permission_role_role_id_index    INDEX     \   CREATE INDEX permission_role_role_id_index ON public.permission_role USING btree (role_id);
 1   DROP INDEX public.permission_role_role_id_index;
       public         otjeadbwenlfkc    false    205            �           1259    3312084 #   permission_user_permission_id_index    INDEX     h   CREATE INDEX permission_user_permission_id_index ON public.permission_user USING btree (permission_id);
 7   DROP INDEX public.permission_user_permission_id_index;
       public         otjeadbwenlfkc    false    207            �           1259    3312085    permission_user_user_id_index    INDEX     \   CREATE INDEX permission_user_user_id_index ON public.permission_user USING btree (user_id);
 1   DROP INDEX public.permission_user_user_id_index;
       public         otjeadbwenlfkc    false    207            �           1259    3312086    role_user_role_id_index    INDEX     P   CREATE INDEX role_user_role_id_index ON public.role_user USING btree (role_id);
 +   DROP INDEX public.role_user_role_id_index;
       public         otjeadbwenlfkc    false    213            �           1259    3312087    role_user_user_id_index    INDEX     P   CREATE INDEX role_user_user_id_index ON public.role_user USING btree (user_id);
 +   DROP INDEX public.role_user_user_id_index;
       public         otjeadbwenlfkc    false    213            �           2606    3312088    compras compras_user_id_foreign    FK CONSTRAINT     �   ALTER TABLE ONLY public.compras
    ADD CONSTRAINT compras_user_id_foreign FOREIGN KEY (user_id) REFERENCES public.users(id) ON UPDATE CASCADE ON DELETE CASCADE;
 I   ALTER TABLE ONLY public.compras DROP CONSTRAINT compras_user_id_foreign;
       public       otjeadbwenlfkc    false    217    3830    196            �           2606    3312093 '   estudiantes estudiantes_user_id_foreign    FK CONSTRAINT     �   ALTER TABLE ONLY public.estudiantes
    ADD CONSTRAINT estudiantes_user_id_foreign FOREIGN KEY (user_id) REFERENCES public.users(id) ON UPDATE CASCADE ON DELETE CASCADE;
 Q   ALTER TABLE ONLY public.estudiantes DROP CONSTRAINT estudiantes_user_id_foreign;
       public       otjeadbwenlfkc    false    198    3830    217            �           2606    3312098 '   instructors instructors_user_id_foreign    FK CONSTRAINT     �   ALTER TABLE ONLY public.instructors
    ADD CONSTRAINT instructors_user_id_foreign FOREIGN KEY (user_id) REFERENCES public.users(id) ON UPDATE CASCADE ON DELETE CASCADE;
 Q   ALTER TABLE ONLY public.instructors DROP CONSTRAINT instructors_user_id_foreign;
       public       otjeadbwenlfkc    false    3830    200    217            �           2606    3312103 5   permission_role permission_role_permission_id_foreign    FK CONSTRAINT     �   ALTER TABLE ONLY public.permission_role
    ADD CONSTRAINT permission_role_permission_id_foreign FOREIGN KEY (permission_id) REFERENCES public.permissions(id) ON DELETE CASCADE;
 _   ALTER TABLE ONLY public.permission_role DROP CONSTRAINT permission_role_permission_id_foreign;
       public       otjeadbwenlfkc    false    209    3812    205            �           2606    3312108 /   permission_role permission_role_role_id_foreign    FK CONSTRAINT     �   ALTER TABLE ONLY public.permission_role
    ADD CONSTRAINT permission_role_role_id_foreign FOREIGN KEY (role_id) REFERENCES public.roles(id) ON DELETE CASCADE;
 Y   ALTER TABLE ONLY public.permission_role DROP CONSTRAINT permission_role_role_id_foreign;
       public       otjeadbwenlfkc    false    215    205    3824            �           2606    3312113 5   permission_user permission_user_permission_id_foreign    FK CONSTRAINT     �   ALTER TABLE ONLY public.permission_user
    ADD CONSTRAINT permission_user_permission_id_foreign FOREIGN KEY (permission_id) REFERENCES public.permissions(id) ON DELETE CASCADE;
 _   ALTER TABLE ONLY public.permission_user DROP CONSTRAINT permission_user_permission_id_foreign;
       public       otjeadbwenlfkc    false    3812    209    207            �           2606    3312118 /   permission_user permission_user_user_id_foreign    FK CONSTRAINT     �   ALTER TABLE ONLY public.permission_user
    ADD CONSTRAINT permission_user_user_id_foreign FOREIGN KEY (user_id) REFERENCES public.users(id) ON DELETE CASCADE;
 Y   ALTER TABLE ONLY public.permission_user DROP CONSTRAINT permission_user_user_id_foreign;
       public       otjeadbwenlfkc    false    3830    217    207                        2606    3312123 #   role_user role_user_role_id_foreign    FK CONSTRAINT     �   ALTER TABLE ONLY public.role_user
    ADD CONSTRAINT role_user_role_id_foreign FOREIGN KEY (role_id) REFERENCES public.roles(id) ON DELETE CASCADE;
 M   ALTER TABLE ONLY public.role_user DROP CONSTRAINT role_user_role_id_foreign;
       public       otjeadbwenlfkc    false    213    3824    215                       2606    3312128 #   role_user role_user_user_id_foreign    FK CONSTRAINT     �   ALTER TABLE ONLY public.role_user
    ADD CONSTRAINT role_user_user_id_foreign FOREIGN KEY (user_id) REFERENCES public.users(id) ON DELETE CASCADE;
 M   ALTER TABLE ONLY public.role_user DROP CONSTRAINT role_user_user_id_foreign;
       public       otjeadbwenlfkc    false    3830    217    213                       2606    3312133 #   vuelos vuelos_id_estudiante_foreign    FK CONSTRAINT     �   ALTER TABLE ONLY public.vuelos
    ADD CONSTRAINT vuelos_id_estudiante_foreign FOREIGN KEY (id_estudiante) REFERENCES public.estudiantes(id) ON UPDATE CASCADE ON DELETE CASCADE;
 M   ALTER TABLE ONLY public.vuelos DROP CONSTRAINT vuelos_id_estudiante_foreign;
       public       otjeadbwenlfkc    false    219    198    3797                       2606    3312138 #   vuelos vuelos_id_instructor_foreign    FK CONSTRAINT     �   ALTER TABLE ONLY public.vuelos
    ADD CONSTRAINT vuelos_id_instructor_foreign FOREIGN KEY (id_instructor) REFERENCES public.instructors(id) ON UPDATE CASCADE ON DELETE CASCADE;
 M   ALTER TABLE ONLY public.vuelos DROP CONSTRAINT vuelos_id_instructor_foreign;
       public       otjeadbwenlfkc    false    200    219    3799            }   �   x�m�m
1D'���L�~�,��fEc�,�m�1���E��d5(A�����U1V:��c;%�+ ��+�A��+2Z���,�:\O�8���Ś\�߲\�cT�a�L4@j�e����$X��)�-;��/�V1�"��;�NSPZ��U1ބX�ze1q�]^�a��M7�I���ǝ��!Hp�         E  x���ˎ�J���S����~a5��,"%�('�˦36�����y�Ts�܎F�m(����~�xW����\�|v�Ȥ�ZK�����N�p��f��_�۲ؗ�rp}<{ז����p�僻\T��~"���+$c�SU��jwpU�� 7�Υ7u�X�Pa�RBY �R)$eV�c�S
��G�0K$t~H2L�/����:�S6�Q�,�"�*G�EL��&
�(>c�w�K����h�Fc6e�6��y���Ok��;��(����k������� ��Vh;df������I��������DQ�PF;,�ߋ&X�09j��l��פ?�4�A8M�̑���U?�{�m�PC9�z�
��a����~��T�>1Z0�̔��Lrr'כ�˵T+�$����	��؏�:GNN�b��(e�V�n[�[c��	�2��]���f��,�H���l$�s߸�l���][{��W�7�����Ij���/5�U7;|����R�r&�b	�J5��T���1�,�&������L��3#��L��ӥ����#��YRr��e��X�Èܻ���4�L+�����RqiŘf��r�J]�k𖔲�#�\�%��йczrwh�����ۮ6Y�8NwW��Uӆ
�}_nq��P�1/q��̻��>���S�X�%q:x�4L�әa<�ZM���f�G�g؀������7��7�|��7�T~��jܻ�T!w���u�5#㖱���D㸹(��
p��K���<�E�,8N�1#2i�3_?���O��gcm��!a���/�}
�c��X�-_�	S�\ҵX�)K��;�*      �   4  x����N�0���S�Z9�G�������tjԭC�ӓvcCbG�W�~Q��K���S�Z	c��"m AyV9r2�)*�a��5uیA@�S�C�>��7��*H���lr�"d�=��$22��{	]Q���0!j*��*�X逐0G�췋Ejz�ò��_�s,sE+e*��н\F`�)�2n#l���A�w$���/0<�J͒�K0��C��O�Ґ��'b��cCN��d�����^��pŲk�A�յ8Sr��5�_fb�'�N/SJ7�C��q7T�*k�P�;�LY-7�9�s}e0{-�,��g��      �   �   x�m���� ���0���2�2I�*�����3;8}K��dF�p�5�����do؈�\MO��6�X"�G� -���&[�|�J�/�X,:?��yatK�ݾqI���m�HwF���H`3Vۏf:q�m^�ֻ�Ť���ԇ/#���fhR�H��n��j��4)M��6�m��]"����R}�ˏK�>Uwտ�(~�Yi�Իy���Tlˈ$e{ٟ�N���W�4�����      �   q   x�K�M�)�24qH�M���K���T1�T14P�ϩ�,�(.���*����O�̈H��2��1.��7ww*�,
3�(�4M.��+q�420��50�56P04�25�21����� �0      �      x��ӻ1�xU�8CK�~W����,��'%& @���s�u9_�O�'��Y�S	����	�)w�/��l������&2���M��M��1�oѬc�pֱ�<�yn�<�E~��Ŀ0��ޭ�/�岻      �      x������ � �      �   E  x����r� ���)X��d,���l;�e�̪*��.���V�/�+l	$���B�,.��3rEً��,m]ˬ4��NXw)5o�A:��;ա�zÍ�
���r���*�g��V���EU��殾�����lS�'aa�gJ	��W;I�g�*���Y_V�yE�l��:�7+��ݸ�shZ�~��dބb�J��Wr/����pޚ�8��~zj���ϥ���"��i7a��&�I.�ڑoV������"�۰��}�ԿR���kR�E˔J�F;ă�8�T��6��[.�����~�2IiA5uN\qā�(��c;a琵�Z�q0a�v[���҅�׊�ĒD��,z1�W�0����5c,*�dzY7��ʰhǵI
"}��q�x���X�hc�-v�x���\�i�UJ8f��᠞�&����� r�<�8+1�%s�`
��� 2�\�S��M0%?d 9>YJ�ټR�YX�D�5�x�PJ2I�ɪ=E63�D2�Nd18���'B�1�y�b��L����?�?��T���a�%,�LBac4Щ������a��@�;����f���4      �      x������ � �      �   T   x�m���0ki
/���c;"x�9�*i� ��Γa��$w�Cv��X�x�v�Ff��Y�x�������T����/a{�      �   �   x�m�M
� ��z�w�?MҺ�Pr7��VH4���+��M6���se�����O�̴Tw!'�4��գ��)��"|H�����Z�,�UR�'$�v����Vh%X1�.���
ߩ���h�`�<en���9�q�8�      �   �
  x�mXG��Z��U0���&G_	!!H��!o�fW���X����d/b�yo��(�eZ����{�;�������<��"2��d�ֳys�᧺��=��������`�l�|�I�^�μv��g
t�S��e��6Tٜ#�1�K��0�|9�-�\R/n��n�$���'L�� [� ��z�mpHK�>,���4`Y<��<��tť�����-<�1t�(�g.�_ ��L�x5s�3]^�X5XR���K�#�B�+ʉ����L㩩�ʄ�<�7L�a��7�E8����#أ��������"��JG�qR���Z�6 j~~������i����v�'��ZG9��}>��݉�β@j�6�P�=ys�7Ov�h�~��rT����X�I	^�	{��xY���vn�Z1�܌?�����Ǫ��q
:ƕ�`+��=(���KA���w'�y�eT%�9}aӻy�u��)���R�1���2�)sk2{<.�o�	_�Ɉ�iaʁ% �h`鸒.�l��B��q����a�_��!?P���q�ҵ��ռ" � �#������#��ҙMR8Ηɳ;ײz^��S�%������9H	�@���|kzVM"8э�<f�`QT�F;Ȑ��Cu���sgQ@Ô�ܪ� �W6���XW�5��ѿU�_n��Pؤ~���g6�/�	v���5���l:Y�_�$�窧Y'���\ۨ�t�8G����!t���,��j��%�i��e�H�Ƈ��T%��:��3s*e�׻L�#�����L:��71��6��[��V�k�So�Ry�L��Y�%��¬����]�©Ðǹ��ʼ�}��Z�7{ؾ��O�P>"U��'B�ZB��R}@_�z!�H U�^+|�js�м����x�
����z�mh�4�.�O�&��`�i�{ZDD����KQ��w��س���(W5j��ή����#��G]�;г�`�:hMi��9�~b�"z����3ޝ/�JB~$3^�tda)�F���c[��~���65^䭳4��'R��0�+��c�³TlΠ��\&T���[�B�P;��y:ʆ톞8�w�%u7����]s:�z���ψTF���]�\��0���(���܆+唿��:u��z�m�Pm;0xͺQ������|��b��vu~!�Rj��I�)c��v��^pTw�]�z ��i7. ����߯���\�M�Ч��s��L����ҁzx�ء=bג�|UL��;n���Wu��y�H ����Hf�����r%���o�N�������K@�����="�¨�ʬ��A��:7���]|^��`-+w����T�����E�؞Y���XOĨ]�7��^����'�A0��=���&��q��w��@� ��lp�'K�&:$F�=�/,�s=�,8���r������d�Nw���[�QO�m��zHz5gaXfP=��b�^�	���p�d^�_�#��w������mԬ��b���o��2MDU;}��/��_Lx�N@������r�x�V�u��C�
�?��Z�"O[������T��%��vt9�ʏe��a�4���0�hz,�L\x���;n���U6��k��Z���~ws#��Yf)Z�JQv�x�E10W9bF�O�+�S,2����ʒ���78�DQ,̋��H�����\�kN�2�J��p�8�J���W���۬���כ���V �|N0��B���%���/CF��kę�;�(����$w�F)O���
[(|B���,���)��=�X��i�Do*��R��c
Y�h4	?��<���v��W��؅�q�uB7^_l[����]r���>�|��\;�����E��ߩ���USi�x�,�*<�թ!56�����y�`��m�Gv�3�3_��2ђ��H�p�f���3�7���j�?0��Y.ɚ��^���y����w/�+l�r�seM��a�U����ف��a����i޻��DN_%�%Tg���>��,(�3l4�C�6������Q-3U$�r�Ѥ^LXM��n��S>��@yXi��ڮҢ ��d�p�z�����n�_��/��Њ�9r���[�����u]��|j���!O�"�Qu�Z�* i��X��+����D��	ȥ�Ů�f���B��_u�����Aa�[��zU�xA�}��ލb�kw��)M��ʘ,�""�+�n5E!���kzD�.�:����=B�#��3�%Iӌ+�0U�m��>�t?�0���x�Q���2K�+I�P�zc\�ȷ[�n�"���n}�|�����́ � V%�6OFY�mtsT�rj*�ϩ;�V8Q kN�t���]�Nɚ�?�/�&
�����R�E:{f��&c�2s�>dO����������۠T�z
��}	����7�k��I=�r.�=?Y�,��`�	Y�6H��dg/Lx'�K>��C��'9���_5��LuYzd�MtA�9��^2؈�S2��8��\��$Sk�?`�����yU��j}d�@E� on+dz�2��dIH����r!P��	���O)���LQy�e=n|)�P��An�����,:�X�����A}�:���洳��u�h�yp8�v}_��jG�q����V�Z�_��yFޔ#�]��J0�?9�#nOT�F&6����+\��cE�$��zs�Qݧ��Y�4��i��63������x~I�\�M�Lx���\�j�q���?�KA�w��v�����wy\      �   �   x���K
�0��u��@�Lޝ��)҅`�U����b)�n����c	+H�Ph�Vb��ŐS�o��x>Hc��ߐecغZ��C��0����Xk`�U<L��-6|!����q�݇>M��W�2�LTk���#�X&d�'J�V����W�F���r��1��A�~����2�	�' /k�|5     