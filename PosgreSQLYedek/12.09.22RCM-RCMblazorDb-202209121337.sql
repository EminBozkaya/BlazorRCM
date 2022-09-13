--
-- PostgreSQL database dump
--

-- Dumped from database version 14.1
-- Dumped by pg_dump version 14.1

-- Started on 2022-09-12 13:37:37

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

DROP DATABASE "RCMblazorDb";
--
-- TOC entry 3533 (class 1262 OID 19620)
-- Name: RCMblazorDb; Type: DATABASE; Schema: -; Owner: -
--

CREATE DATABASE "RCMblazorDb" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'Turkish_Turkey.1254';


\connect "RCMblazorDb"

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
-- TOC entry 4 (class 2615 OID 2200)
-- Name: public; Type: SCHEMA; Schema: -; Owner: -
--

CREATE SCHEMA public;


--
-- TOC entry 3534 (class 0 OID 0)
-- Dependencies: 4
-- Name: SCHEMA public; Type: COMMENT; Schema: -; Owner: -
--

COMMENT ON SCHEMA public IS 'standard public schema';


SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 212 (class 1259 OID 19627)
-- Name: AuthorityType; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."AuthorityType" (
    "Id" smallint NOT NULL,
    "Type" character varying
);


--
-- TOC entry 211 (class 1259 OID 19626)
-- Name: AuthorityType_Id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public."AuthorityType" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."AuthorityType_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 214 (class 1259 OID 19635)
-- Name: Branch; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."Branch" (
    "Id" smallint NOT NULL,
    "Name" character varying NOT NULL,
    "Adress" character varying NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedTime" date DEFAULT CURRENT_DATE NOT NULL,
    "ModifiedTime" date
);


--
-- TOC entry 231 (class 1259 OID 19795)
-- Name: BranchProductPrice; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."BranchProductPrice" (
    "BId" smallint NOT NULL,
    "PId" smallint NOT NULL,
    "BranchPrice" numeric NOT NULL,
    "VATpercent" numeric,
    "IsFavorite" boolean,
    "IsActive" boolean NOT NULL
);


--
-- TOC entry 228 (class 1259 OID 19727)
-- Name: BranchSupplier; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."BranchSupplier" (
    "Id" integer NOT NULL,
    "BId" smallint NOT NULL,
    "SpId" integer NOT NULL,
    "CreatedBy" integer NOT NULL,
    "ModifiedBy" integer NOT NULL,
    "CreatedTime" date DEFAULT CURRENT_DATE NOT NULL,
    "ModifiedTime" date,
    "IsActive" boolean NOT NULL
);


--
-- TOC entry 227 (class 1259 OID 19726)
-- Name: BranchSupplier_Id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public."BranchSupplier" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."BranchSupplier_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 213 (class 1259 OID 19634)
-- Name: Branch_Id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public."Branch" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Branch_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 216 (class 1259 OID 19644)
-- Name: FirmType; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."FirmType" (
    "Id" smallint NOT NULL,
    "Name" character varying
);


--
-- TOC entry 215 (class 1259 OID 19643)
-- Name: FirmType_Id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public."FirmType" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."FirmType_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 222 (class 1259 OID 19674)
-- Name: Product; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."Product" (
    "Id" smallint NOT NULL,
    "Name" character varying NOT NULL,
    "CatId" smallint NOT NULL,
    "Price" numeric(19,4),
    "VATpercent" numeric,
    "IsActive" boolean NOT NULL,
    "ColorCode" smallint,
    "MenuListId" smallint
);


--
-- TOC entry 218 (class 1259 OID 19652)
-- Name: ProductCategory; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."ProductCategory" (
    "Id" smallint NOT NULL,
    "Name" character varying NOT NULL,
    "TopCatId" smallint,
    "IsActive" boolean NOT NULL
);


--
-- TOC entry 217 (class 1259 OID 19651)
-- Name: ProductCategory_Id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public."ProductCategory" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."ProductCategory_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 236 (class 1259 OID 19896)
-- Name: ProductMenuList; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."ProductMenuList" (
    "Id" smallint NOT NULL,
    "ListName" text,
    "IsActive" boolean NOT NULL
);


--
-- TOC entry 235 (class 1259 OID 19895)
-- Name: ProductMenuList_Id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public."ProductMenuList" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."ProductMenuList_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 238 (class 1259 OID 19911)
-- Name: ProductSaleNote; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."ProductSaleNote" (
    "Id" smallint NOT NULL,
    "Definition" text,
    "NoteCat" smallint
);


--
-- TOC entry 240 (class 1259 OID 19949)
-- Name: ProductSaleNoteCategory; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."ProductSaleNoteCategory" (
    "Id" smallint NOT NULL,
    "NotCat" text
);


--
-- TOC entry 239 (class 1259 OID 19948)
-- Name: ProductSaleNoteCategory_Id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public."ProductSaleNoteCategory" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."ProductSaleNoteCategory_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 237 (class 1259 OID 19910)
-- Name: ProductSaleNote_Id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public."ProductSaleNote" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."ProductSaleNote_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 221 (class 1259 OID 19673)
-- Name: Product_Id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public."Product" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Product_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 233 (class 1259 OID 19848)
-- Name: Sale; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."Sale" (
    "Id" integer NOT NULL,
    "BId" smallint NOT NULL,
    "DateTime" timestamp without time zone DEFAULT now() NOT NULL,
    "UId" integer NOT NULL,
    "SaleNote" text,
    "IsEOD" boolean NOT NULL,
    "EOD" date,
    "IsActive" boolean NOT NULL,
    "TotalPrice" numeric DEFAULT 0.0 NOT NULL,
    "DailyBillOrder" integer NOT NULL,
    "DeletedBy" integer,
    "DeletedTime" timestamp without time zone,
    "IsModified" boolean,
    "ModifiedBy" integer,
    "ModifiedTime" timestamp without time zone,
    "STId" smallint
);


--
-- TOC entry 234 (class 1259 OID 19866)
-- Name: SaleDetail; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."SaleDetail" (
    "Id" uuid DEFAULT public.uuid_generate_v4() NOT NULL,
    "SId" integer NOT NULL,
    "PId" smallint NOT NULL,
    "Price" numeric NOT NULL,
    "Portion" numeric NOT NULL,
    "Qty" smallint NOT NULL,
    "Total" numeric NOT NULL,
    "Note" text,
    "ModifiedBy" integer,
    "ModifiedTime" timestamp with time zone,
    "IsActive" boolean NOT NULL,
    "firstProductNote" text,
    "generalProductNote" text,
    "secondProductNote" text,
    "thirdProductNote" text,
    "BillOrder" smallint
);


--
-- TOC entry 243 (class 1259 OID 20015)
-- Name: SaleType; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."SaleType" (
    "Id" smallint NOT NULL,
    "Type" character varying NOT NULL,
    "IsActive" boolean,
    "TopSTId" smallint
);


--
-- TOC entry 242 (class 1259 OID 20014)
-- Name: SaleType_Id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public."SaleType" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."SaleType_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 241 (class 1259 OID 20006)
-- Name: Sale_DailyBillOrder_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public."Sale" ALTER COLUMN "DailyBillOrder" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."Sale_DailyBillOrder_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 232 (class 1259 OID 19847)
-- Name: Sale_Id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public."Sale" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Sale_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 224 (class 1259 OID 19687)
-- Name: Supplier; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."Supplier" (
    "Id" integer NOT NULL,
    "CompanyName" character varying NOT NULL,
    "Adress" character varying,
    "CreatedBy" integer NOT NULL,
    "ModifiedBy" integer NOT NULL,
    "CreatedTime" date DEFAULT CURRENT_DATE NOT NULL,
    "ModifiedTime" date,
    "IsActive" boolean NOT NULL
);


--
-- TOC entry 230 (class 1259 OID 19754)
-- Name: SupplierFirmType; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."SupplierFirmType" (
    "Id" integer NOT NULL,
    "SpId" integer NOT NULL,
    "FtId" smallint NOT NULL,
    "CreatedBy" integer NOT NULL,
    "ModifiedBy" integer NOT NULL,
    "CreatedTime" date DEFAULT CURRENT_DATE NOT NULL,
    "ModifiedTime" date,
    "IsActive" boolean NOT NULL
);


--
-- TOC entry 229 (class 1259 OID 19753)
-- Name: SupplierFirmType_Id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public."SupplierFirmType" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."SupplierFirmType_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 223 (class 1259 OID 19686)
-- Name: Supplier_Id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public."Supplier" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Supplier_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 220 (class 1259 OID 19665)
-- Name: User; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."User" (
    "Id" integer NOT NULL,
    "FirstName" character varying NOT NULL,
    "LastName" character varying NOT NULL,
    "UserName" character varying NOT NULL,
    "Phone" character(10) NOT NULL,
    "Email" character varying NOT NULL,
    "Password" character varying NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedTime" date DEFAULT CURRENT_DATE NOT NULL,
    "ModifiedTime" date
);


--
-- TOC entry 226 (class 1259 OID 19706)
-- Name: UserBranchAuthority; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."UserBranchAuthority" (
    "Id" integer NOT NULL,
    "UId" integer NOT NULL,
    "BId" smallint NOT NULL,
    "ATId" smallint NOT NULL,
    "IsActive" boolean NOT NULL
);


--
-- TOC entry 225 (class 1259 OID 19705)
-- Name: UserBranchAuthority_Id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public."UserBranchAuthority" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."UserBranchAuthority_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 219 (class 1259 OID 19664)
-- Name: User_Id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public."User" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."User_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 210 (class 1259 OID 19621)
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


--
-- TOC entry 3496 (class 0 OID 19627)
-- Dependencies: 212
-- Data for Name: AuthorityType; Type: TABLE DATA; Schema: public; Owner: -
--

INSERT INTO public."AuthorityType" OVERRIDING SYSTEM VALUE VALUES (1, 'Marka Sahibi');
INSERT INTO public."AuthorityType" OVERRIDING SYSTEM VALUE VALUES (2, 'CEO');
INSERT INTO public."AuthorityType" OVERRIDING SYSTEM VALUE VALUES (3, 'MYK');
INSERT INTO public."AuthorityType" OVERRIDING SYSTEM VALUE VALUES (4, 'Reklam/Ajans');
INSERT INTO public."AuthorityType" OVERRIDING SYSTEM VALUE VALUES (5, 'Bölge Müdürü');
INSERT INTO public."AuthorityType" OVERRIDING SYSTEM VALUE VALUES (6, 'Kasiyer');
INSERT INTO public."AuthorityType" OVERRIDING SYSTEM VALUE VALUES (7, 'Kurye');
INSERT INTO public."AuthorityType" OVERRIDING SYSTEM VALUE VALUES (8, 'Şube Müdürü');


--
-- TOC entry 3498 (class 0 OID 19635)
-- Dependencies: 214
-- Data for Name: Branch; Type: TABLE DATA; Schema: public; Owner: -
--

INSERT INTO public."Branch" OVERRIDING SYSTEM VALUE VALUES (1, 'avm', 'amasya', true, '2022-04-01', '2022-04-01');
INSERT INTO public."Branch" OVERRIDING SYSTEM VALUE VALUES (2, 'merkez', 'amasya', true, '2022-04-01', '2022-04-01');
INSERT INTO public."Branch" OVERRIDING SYSTEM VALUE VALUES (3, 'Erzurum', 'doğu', true, '2022-04-08', '2022-04-08');
INSERT INTO public."Branch" OVERRIDING SYSTEM VALUE VALUES (4, 'erba', 'tokat', true, '2022-04-09', '2022-04-09');
INSERT INTO public."Branch" OVERRIDING SYSTEM VALUE VALUES (5, 'merzifon', 'AMAS', true, '2022-04-01', '2022-04-09');
INSERT INTO public."Branch" OVERRIDING SYSTEM VALUE VALUES (6, 'fatsa', 'Ordu', true, '2022-04-09', '2022-04-09');


--
-- TOC entry 3515 (class 0 OID 19795)
-- Dependencies: 231
-- Data for Name: BranchProductPrice; Type: TABLE DATA; Schema: public; Owner: -
--

INSERT INTO public."BranchProductPrice" VALUES (2, 3, 32.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 4, 35.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 5, 27.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 6, 24.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 7, 30.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 8, 30.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 9, 42.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 10, 45.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 11, 37.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 12, 32.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 43, 4.50, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 1, 22.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 2, 22.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 4, 35.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 5, 27.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 6, 24.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 7, 30.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 8, 30.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 9, 42.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 10, 45.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 11, 37.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 12, 32.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 13, 37.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 14, 34.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 17, 45.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 18, 42.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 21, 20.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 24, 2.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 26, 9.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 29, 9.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 30, 9.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 3, 32.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 15, 41.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 16, 38.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 19, 52.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 20, 49.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 22, 20.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 27, 9.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 28, 9.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 31, 9.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 32, 9.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 33, 9.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 34, 9.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 35, 9.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 36, 9.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 37, 9.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 38, 9.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 39, 9.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 40, 9.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 41, 2.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 42, 6.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 44, 4.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 45, 5.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 46, 5.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 47, 5.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 48, 5.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 49, 5.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 50, 0.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 51, 0.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 25, 4.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 1, 22.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 2, 22.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 13, 37.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 14, 34.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 15, 41.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 16, 38.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 17, 45.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 18, 42.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 19, 52.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 20, 49.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 21, 20.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 22, 20.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 23, 9.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 24, 2.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 25, 4.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 26, 9.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 27, 9.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 28, 9.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 29, 9.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 30, 9.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 31, 9.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 32, 9.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 33, 9.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 34, 9.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 35, 9.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 36, 9.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 37, 9.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 38, 9.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 39, 9.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 40, 9.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 41, 2.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 42, 6.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 43, 4.50, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 44, 4.00, NULL, true, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 45, 5.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 46, 5.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 47, 5.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 48, 5.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 49, 5.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 50, 0.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (2, 51, 0.00, NULL, false, true);
INSERT INTO public."BranchProductPrice" VALUES (1, 23, 10.00, NULL, true, true);


--
-- TOC entry 3512 (class 0 OID 19727)
-- Dependencies: 228
-- Data for Name: BranchSupplier; Type: TABLE DATA; Schema: public; Owner: -
--



--
-- TOC entry 3500 (class 0 OID 19644)
-- Dependencies: 216
-- Data for Name: FirmType; Type: TABLE DATA; Schema: public; Owner: -
--



--
-- TOC entry 3506 (class 0 OID 19674)
-- Dependencies: 222
-- Data for Name: Product; Type: TABLE DATA; Schema: public; Owner: -
--

INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (7, 'Et Dürüm', 5, NULL, NULL, true, 7, 1);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (3, 'Tavuk Servis', 21, NULL, NULL, true, 5, 1);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (4, 'Tavuk İskender', 21, NULL, NULL, true, 5, 1);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (9, 'Et Servis', 22, NULL, NULL, true, 7, 1);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (10, 'Et İskender', 22, NULL, NULL, true, 7, 1);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (13, 'Tavuk Combo', 9, NULL, NULL, true, 5, 2);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (14, 'Tavuk Avantaj', 9, NULL, NULL, true, 5, 2);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (15, 'Tavuk Zurna Combo', 9, NULL, NULL, true, 5, 2);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (16, 'Tavuk Zurna Avantaj', 9, NULL, NULL, true, 5, 2);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (17, 'Et Combo', 10, NULL, NULL, true, 7, 2);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (18, 'Et Avantaj', 10, NULL, NULL, true, 7, 2);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (19, 'Et Zurna Combo', 10, NULL, NULL, true, 7, 2);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (20, 'Et Zurna Avantaj', 10, NULL, NULL, true, 7, 2);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (21, 'Vejetaryen Dürüm', 6, NULL, NULL, true, 2, 1);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (22, 'Vejetaryen Ekmek', 6, NULL, NULL, true, 2, 1);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (31, 'IceTea Limon', 26, NULL, NULL, true, 1, 3);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (32, 'IceTea Mango', 26, NULL, NULL, true, 1, 3);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (33, 'IceTea Karpuz', 26, NULL, NULL, true, 1, 3);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (34, 'M.Suyu Karışık', 25, NULL, NULL, true, 1, 3);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (35, 'M.Suyu Şeftali', 25, NULL, NULL, true, 1, 3);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (36, 'M.Suyu Portakal', 25, NULL, NULL, true, 1, 3);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (37, 'M.Suyu Vişne', 25, NULL, NULL, true, 1, 3);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (38, 'M.Suyu Kayısı', 25, NULL, NULL, true, 1, 3);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (26, 'Pepsi', 23, NULL, NULL, true, 1, 3);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (27, 'Pepsi Max', 23, NULL, NULL, true, 1, 3);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (28, 'Pepsi Twist', 23, NULL, NULL, true, 1, 3);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (29, 'Yedigün', 19, NULL, NULL, true, 1, 3);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (30, 'IceTea Şeftali', 26, NULL, NULL, true, 1, 3);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (40, 'Fruko 7UP', 19, NULL, NULL, true, 1, 3);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (41, 'Küçük Su', 18, NULL, NULL, true, 1, 3);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (39, 'Fruko Gazoz', 19, NULL, NULL, true, 1, 3);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (42, 'Büyük Ayran', 27, NULL, NULL, true, 1, 3);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (43, 'Küçük Ayran', 27, NULL, NULL, true, 1, 3);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (44, 'Sade Soda', 28, NULL, NULL, true, 1, 3);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (45, 'Limonlu Soda', 29, NULL, NULL, true, 1, 3);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (46, 'Elmalı Soda', 29, NULL, NULL, true, 1, 3);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (47, 'Karpuzlu Soda', 29, NULL, NULL, true, 1, 3);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (48, 'Vişneli Soda', 29, NULL, NULL, true, 1, 3);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (49, 'Çilekli Soda', 29, NULL, NULL, true, 1, 3);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (50, 'Personel Tavuk', 4, NULL, NULL, true, 8, 1);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (51, 'Personel Et', 5, NULL, NULL, true, 8, 1);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (1, 'Tavuk Dürüm', 4, NULL, NULL, true, 5, 1);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (2, 'Tavuk Ekmek', 4, NULL, NULL, true, 5, 1);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (5, 'Tavuk Zurna', 4, NULL, NULL, true, 5, 1);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (6, 'Tavuk Dürüm Çift Lvş', 4, NULL, NULL, true, 5, 1);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (8, 'Et Ekmek', 5, NULL, NULL, true, 7, 1);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (11, 'Et Zurna', 5, NULL, NULL, true, 7, 1);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (12, 'Et Dürüm Çift Lvş', 5, NULL, NULL, true, 7, 1);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (23, 'Patates', 7, NULL, NULL, true, 6, 4);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (24, 'Yarım Lavaş', 7, NULL, NULL, true, 9, 4);
INSERT INTO public."Product" OVERRIDING SYSTEM VALUE VALUES (25, '1 Lavaş', 7, NULL, NULL, true, 9, 4);


--
-- TOC entry 3502 (class 0 OID 19652)
-- Dependencies: 218
-- Data for Name: ProductCategory; Type: TABLE DATA; Schema: public; Owner: -
--

INSERT INTO public."ProductCategory" OVERRIDING SYSTEM VALUE VALUES (1, 'Yiyecek', NULL, true);
INSERT INTO public."ProductCategory" OVERRIDING SYSTEM VALUE VALUES (2, 'İçecek', NULL, true);
INSERT INTO public."ProductCategory" OVERRIDING SYSTEM VALUE VALUES (3, 'Tatlı', NULL, true);
INSERT INTO public."ProductCategory" OVERRIDING SYSTEM VALUE VALUES (4, 'Tavuk', 1, true);
INSERT INTO public."ProductCategory" OVERRIDING SYSTEM VALUE VALUES (5, 'Et', 1, true);
INSERT INTO public."ProductCategory" OVERRIDING SYSTEM VALUE VALUES (6, 'Diğer Yiyecek', 1, true);
INSERT INTO public."ProductCategory" OVERRIDING SYSTEM VALUE VALUES (7, 'Yan Ürün', 1, true);
INSERT INTO public."ProductCategory" OVERRIDING SYSTEM VALUE VALUES (8, 'Menü', NULL, true);
INSERT INTO public."ProductCategory" OVERRIDING SYSTEM VALUE VALUES (9, 'Tavuk Menü', 8, true);
INSERT INTO public."ProductCategory" OVERRIDING SYSTEM VALUE VALUES (10, 'Et Menü', 8, true);
INSERT INTO public."ProductCategory" OVERRIDING SYSTEM VALUE VALUES (11, 'Ramazan Menü', 8, true);
INSERT INTO public."ProductCategory" OVERRIDING SYSTEM VALUE VALUES (12, 'Ramazan Tavuk Menü', 11, true);
INSERT INTO public."ProductCategory" OVERRIDING SYSTEM VALUE VALUES (13, 'Ramazan Et Menü', 11, true);
INSERT INTO public."ProductCategory" OVERRIDING SYSTEM VALUE VALUES (14, '2,5 LT İçecek', 2, true);
INSERT INTO public."ProductCategory" OVERRIDING SYSTEM VALUE VALUES (15, '2 LT İçecek', 2, true);
INSERT INTO public."ProductCategory" OVERRIDING SYSTEM VALUE VALUES (16, '1,5 LT İçecek', 2, true);
INSERT INTO public."ProductCategory" OVERRIDING SYSTEM VALUE VALUES (17, '1 LT İçecek', 2, true);
INSERT INTO public."ProductCategory" OVERRIDING SYSTEM VALUE VALUES (18, '0,5 LT İçecek', 2, true);
INSERT INTO public."ProductCategory" OVERRIDING SYSTEM VALUE VALUES (19, 'Kutu İçecek', 2, true);
INSERT INTO public."ProductCategory" OVERRIDING SYSTEM VALUE VALUES (20, 'Cam Şişe', 2, true);
INSERT INTO public."ProductCategory" OVERRIDING SYSTEM VALUE VALUES (21, 'Tavuk Servis/Tabak', 4, true);
INSERT INTO public."ProductCategory" OVERRIDING SYSTEM VALUE VALUES (22, 'Et Servis/Tabak', 5, true);
INSERT INTO public."ProductCategory" OVERRIDING SYSTEM VALUE VALUES (23, 'Kutu Pepsi', 19, true);
INSERT INTO public."ProductCategory" OVERRIDING SYSTEM VALUE VALUES (24, 'Kutu Lipton', 19, true);
INSERT INTO public."ProductCategory" OVERRIDING SYSTEM VALUE VALUES (25, 'Kutu Lipton Tropicana', 24, true);
INSERT INTO public."ProductCategory" OVERRIDING SYSTEM VALUE VALUES (26, 'Kutu Lipton Ice Tea', 24, true);
INSERT INTO public."ProductCategory" OVERRIDING SYSTEM VALUE VALUES (27, 'Ayran', 2, true);
INSERT INTO public."ProductCategory" OVERRIDING SYSTEM VALUE VALUES (28, 'Soda', 20, true);
INSERT INTO public."ProductCategory" OVERRIDING SYSTEM VALUE VALUES (29, 'Meyveli Soda', 28, true);


--
-- TOC entry 3520 (class 0 OID 19896)
-- Dependencies: 236
-- Data for Name: ProductMenuList; Type: TABLE DATA; Schema: public; Owner: -
--

INSERT INTO public."ProductMenuList" OVERRIDING SYSTEM VALUE VALUES (2, 'Menüler', true);
INSERT INTO public."ProductMenuList" OVERRIDING SYSTEM VALUE VALUES (3, 'İçecekler', true);
INSERT INTO public."ProductMenuList" OVERRIDING SYSTEM VALUE VALUES (4, 'Yan Ürün ve Diğer', true);
INSERT INTO public."ProductMenuList" OVERRIDING SYSTEM VALUE VALUES (1, 'Dürüm ve Servis', true);


--
-- TOC entry 3522 (class 0 OID 19911)
-- Dependencies: 238
-- Data for Name: ProductSaleNote; Type: TABLE DATA; Schema: public; Owner: -
--

INSERT INTO public."ProductSaleNote" OVERRIDING SYSTEM VALUE VALUES (1, 'Bol Sos', 1);
INSERT INTO public."ProductSaleNote" OVERRIDING SYSTEM VALUE VALUES (2, 'Bol Mayonez', 1);
INSERT INTO public."ProductSaleNote" OVERRIDING SYSTEM VALUE VALUES (3, 'Bol Turşu', 1);
INSERT INTO public."ProductSaleNote" OVERRIDING SYSTEM VALUE VALUES (4, 'Bol Patates', 1);
INSERT INTO public."ProductSaleNote" OVERRIDING SYSTEM VALUE VALUES (5, 'Bol Domates', 1);
INSERT INTO public."ProductSaleNote" OVERRIDING SYSTEM VALUE VALUES (6, 'Bol Yeşillik', 1);
INSERT INTO public."ProductSaleNote" OVERRIDING SYSTEM VALUE VALUES (7, 'Bol Soğan', 1);
INSERT INTO public."ProductSaleNote" OVERRIDING SYSTEM VALUE VALUES (8, 'Sossuz', 3);
INSERT INTO public."ProductSaleNote" OVERRIDING SYSTEM VALUE VALUES (9, 'Mayonezsiz', 3);
INSERT INTO public."ProductSaleNote" OVERRIDING SYSTEM VALUE VALUES (10, 'Turşusuz', 3);
INSERT INTO public."ProductSaleNote" OVERRIDING SYSTEM VALUE VALUES (11, 'Patatessiz', 3);
INSERT INTO public."ProductSaleNote" OVERRIDING SYSTEM VALUE VALUES (12, 'Domatessiz', 3);
INSERT INTO public."ProductSaleNote" OVERRIDING SYSTEM VALUE VALUES (13, 'Yeşilliksiz', 3);
INSERT INTO public."ProductSaleNote" OVERRIDING SYSTEM VALUE VALUES (14, 'Soğansız', 3);
INSERT INTO public."ProductSaleNote" OVERRIDING SYSTEM VALUE VALUES (15, 'Acısız', 3);
INSERT INTO public."ProductSaleNote" OVERRIDING SYSTEM VALUE VALUES (16, 'Az Sos', 2);
INSERT INTO public."ProductSaleNote" OVERRIDING SYSTEM VALUE VALUES (17, 'Az Mayonez', 2);
INSERT INTO public."ProductSaleNote" OVERRIDING SYSTEM VALUE VALUES (18, 'Az Turşu', 2);
INSERT INTO public."ProductSaleNote" OVERRIDING SYSTEM VALUE VALUES (19, 'Az Patates', 2);
INSERT INTO public."ProductSaleNote" OVERRIDING SYSTEM VALUE VALUES (20, 'Az Domates', 2);
INSERT INTO public."ProductSaleNote" OVERRIDING SYSTEM VALUE VALUES (21, 'Az Yeşillik', 2);
INSERT INTO public."ProductSaleNote" OVERRIDING SYSTEM VALUE VALUES (22, 'Az Soğan', 2);
INSERT INTO public."ProductSaleNote" OVERRIDING SYSTEM VALUE VALUES (23, 'Az Lavaş', 2);
INSERT INTO public."ProductSaleNote" OVERRIDING SYSTEM VALUE VALUES (24, 'Yarım Lavaş', 5);
INSERT INTO public."ProductSaleNote" OVERRIDING SYSTEM VALUE VALUES (25, 'Kızarmış Lavaş', 5);
INSERT INTO public."ProductSaleNote" OVERRIDING SYSTEM VALUE VALUES (26, 'Yumuşak Lavaş', 5);
INSERT INTO public."ProductSaleNote" OVERRIDING SYSTEM VALUE VALUES (27, 'Kızarmış Tavuk', 6);
INSERT INTO public."ProductSaleNote" OVERRIDING SYSTEM VALUE VALUES (28, 'Az Tavuk', 6);
INSERT INTO public."ProductSaleNote" OVERRIDING SYSTEM VALUE VALUES (29, 'İlave Marul', 4);
INSERT INTO public."ProductSaleNote" OVERRIDING SYSTEM VALUE VALUES (30, 'İlave Domates', 4);
INSERT INTO public."ProductSaleNote" OVERRIDING SYSTEM VALUE VALUES (31, 'İlave Soğan', 4);
INSERT INTO public."ProductSaleNote" OVERRIDING SYSTEM VALUE VALUES (32, 'İlave Patates', 4);
INSERT INTO public."ProductSaleNote" OVERRIDING SYSTEM VALUE VALUES (33, 'İlave Mayonez', 4);
INSERT INTO public."ProductSaleNote" OVERRIDING SYSTEM VALUE VALUES (34, 'İlave Acı', 4);
INSERT INTO public."ProductSaleNote" OVERRIDING SYSTEM VALUE VALUES (35, 'Paket Olacak', 6);
INSERT INTO public."ProductSaleNote" OVERRIDING SYSTEM VALUE VALUES (36, 'Ayrı Poşet', 6);
INSERT INTO public."ProductSaleNote" OVERRIDING SYSTEM VALUE VALUES (37, 'İkiye Bölünsün', 6);
INSERT INTO public."ProductSaleNote" OVERRIDING SYSTEM VALUE VALUES (38, 'Bol Malzeme', 1);


--
-- TOC entry 3524 (class 0 OID 19949)
-- Dependencies: 240
-- Data for Name: ProductSaleNoteCategory; Type: TABLE DATA; Schema: public; Owner: -
--

INSERT INTO public."ProductSaleNoteCategory" OVERRIDING SYSTEM VALUE VALUES (1, 'Bol');
INSERT INTO public."ProductSaleNoteCategory" OVERRIDING SYSTEM VALUE VALUES (2, 'Az');
INSERT INTO public."ProductSaleNoteCategory" OVERRIDING SYSTEM VALUE VALUES (3, 'Çıkar');
INSERT INTO public."ProductSaleNoteCategory" OVERRIDING SYSTEM VALUE VALUES (4, 'İlave');
INSERT INTO public."ProductSaleNoteCategory" OVERRIDING SYSTEM VALUE VALUES (5, 'Lavaş');
INSERT INTO public."ProductSaleNoteCategory" OVERRIDING SYSTEM VALUE VALUES (6, 'Diğer');


--
-- TOC entry 3517 (class 0 OID 19848)
-- Dependencies: 233
-- Data for Name: Sale; Type: TABLE DATA; Schema: public; Owner: -
--

INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (50, 2, '2022-06-24 22:42:08.524697', 9, NULL, false, NULL, true, 88.00, 0, 1, '-infinity', false, 1, '-infinity', 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (51, 2, '2022-06-24 22:58:43.254761', 9, NULL, false, NULL, true, 29.00, 0, 1, '-infinity', false, 1, '-infinity', 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (53, 2, '2022-06-25 00:18:03.078365', 9, NULL, false, NULL, true, 37.00, 0, 1, '-infinity', false, 1, '-infinity', 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (52, 2, '2022-06-24 23:17:40.017425', 9, NULL, true, '2022-06-04', true, 124.00, 0, 1, '-infinity', false, 9, '2022-06-24 23:19:44.524432', 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (55, 2, '2022-06-25 00:58:27.299351', 9, NULL, false, NULL, true, 89.00, 0, 1, '-infinity', false, 9, '2022-06-25 00:59:04.737301', 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (24, 4, '2022-06-19 14:47:32.159739', 3, NULL, false, NULL, true, 62.00, 23, 1, '-infinity', false, 9, '2022-06-25 16:50:05.387576', 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (56, 2, '2022-06-25 18:15:42.037434', 9, NULL, false, NULL, true, 444.00, 0, 1, '-infinity', false, 9, '2022-06-25 18:16:14.246818', 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (57, 2, '2022-06-27 23:02:26.652579', 6, NULL, false, NULL, true, 111.00, 0, 1, '-infinity', false, 1, '-infinity', 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (58, 2, '2022-06-27 23:13:08.77976', 9, NULL, false, NULL, true, 107.00, 0, 1, '-infinity', false, 1, '-infinity', 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (59, 2, '2022-06-27 23:15:48.163404', 9, NULL, false, NULL, true, 176.50, 0, 1, '-infinity', false, 1, '-infinity', 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (61, 2, '2022-06-28 16:19:15.395278', 9, NULL, false, NULL, true, 212.00, 0, 1, '-infinity', false, 1, '-infinity', 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (62, 2, '2022-06-28 16:51:50.999334', 6, NULL, false, NULL, true, 196.00, 0, 1, '-infinity', false, 1, '-infinity', 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (63, 2, '2022-06-28 22:35:40.641803', 6, NULL, false, NULL, true, 153.50, 0, 1, '-infinity', false, 1, '-infinity', 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (64, 2, '2022-06-28 22:37:24.885466', 6, NULL, false, NULL, true, 174.00, 0, 1, '-infinity', false, 1, '-infinity', 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (65, 2, '2022-06-28 22:55:58.833149', 6, NULL, false, NULL, true, 137.00, 0, 1, '-infinity', false, 1, '-infinity', 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (66, 2, '2022-06-28 23:00:46.773844', 9, NULL, false, NULL, true, 174.00, 0, 1, '-infinity', false, 1, '-infinity', 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (67, 2, '2022-07-28 18:59:50.348983', 9, NULL, false, NULL, true, 84.00, 0, 1, '-infinity', false, 1, '-infinity', 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (68, 2, '2022-07-28 19:01:35.334783', 9, NULL, false, NULL, true, 56.00, 0, 1, '-infinity', false, 1, '-infinity', 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (69, 2, '2022-07-28 19:59:57.869426', 9, NULL, false, NULL, true, 97.00, 0, 1, '-infinity', false, 1, '-infinity', 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (70, 2, '2022-07-28 21:16:31.167133', 9, NULL, false, NULL, true, 57.00, 0, 1, '-infinity', false, 1, '-infinity', 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (71, 2, '2022-07-28 21:20:31.855186', 9, NULL, false, NULL, true, 4.00, 0, 1, '-infinity', false, 1, '-infinity', 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (72, 2, '2022-07-28 22:18:00.649337', 9, NULL, false, NULL, true, 69.00, 0, 1, '-infinity', false, 1, '-infinity', 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (73, 2, '2022-07-29 16:26:12.991938', 9, NULL, false, NULL, true, 109.00, 0, 1, '-infinity', false, 1, '-infinity', 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (74, 2, '2022-07-29 16:37:26.130377', 9, NULL, false, NULL, true, 44.00, 0, 1, '-infinity', false, 1, '-infinity', 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (75, 2, '2022-07-30 17:58:19.307944', 9, NULL, false, NULL, true, 102.00, 0, 1, '-infinity', false, 1, '-infinity', 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (76, 2, '2022-07-30 18:01:55.154085', 9, NULL, false, NULL, true, 102.00, 0, 1, '-infinity', false, 1, '-infinity', 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (77, 2, '2022-07-30 18:16:12.713995', 9, NULL, false, NULL, true, 102.00, 0, 1, '-infinity', false, 1, '-infinity', 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (78, 2, '2022-07-30 18:17:25.259692', 9, NULL, false, NULL, true, 31.00, 0, 1, '-infinity', false, 1, '-infinity', 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (79, 2, '2022-07-30 18:18:26.688346', 9, NULL, false, NULL, true, 24.00, 0, 1, '-infinity', false, 1, '-infinity', 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (80, 2, '2022-07-30 18:20:12.966122', 9, NULL, false, NULL, true, 4.00, 0, 1, '-infinity', false, 1, '-infinity', 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (81, 2, '2022-07-30 18:22:00.231335', 9, NULL, false, NULL, true, 4.00, 0, 1, '-infinity', false, 1, '-infinity', 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (82, 2, '2022-07-30 18:22:54.360113', 9, NULL, false, NULL, true, 8.50, 0, 1, '-infinity', false, 1, '-infinity', 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (83, 2, '2022-07-30 18:34:03.429725', 9, NULL, false, NULL, true, 30.00, 0, 1, '-infinity', false, 1, '-infinity', 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (84, 2, '2022-07-30 18:34:32.556728', 9, NULL, false, NULL, true, 37.00, 0, 1, '-infinity', false, 1, '-infinity', 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (85, 2, '2022-07-30 18:43:32.711271', 2, NULL, false, NULL, true, 45.00, 0, 1, '-infinity', false, 1, '-infinity', 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (86, 2, '2022-07-30 18:52:59.838661', 2, NULL, false, NULL, true, 27.00, 0, 1, '-infinity', false, 1, '-infinity', 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (30, 2, '2022-06-19 14:47:58.320183', 9, NULL, false, NULL, true, 22.00, 2, 1, NULL, NULL, 1, NULL, 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (45, 2, '2022-06-21 15:07:17.58014', 9, NULL, false, NULL, true, 97.00, 3, 1, NULL, NULL, 1, NULL, 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (25, 5, '2022-06-19 14:47:36.562265', 9, NULL, true, '2022-06-01', true, 38.00, 4, 1, NULL, NULL, 1, NULL, 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (26, 5, '2022-06-19 14:47:40.424434', 9, NULL, true, '2022-06-01', true, 49.00, 5, 1, NULL, NULL, 1, NULL, 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (27, 5, '2022-06-19 14:47:44.89879', 9, NULL, true, '2022-06-01', true, 2.00, 6, 1, NULL, NULL, 1, NULL, 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (28, 2, '2022-06-19 14:47:51.260711', 9, NULL, true, '2022-06-01', true, 45.00, 7, 1, NULL, NULL, 1, NULL, 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (29, 2, '2022-06-19 14:47:54.984119', 9, NULL, true, '2022-06-01', true, 22.00, 8, 1, NULL, NULL, 1, NULL, 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (31, 2, '2022-06-19 14:48:01.280529', 9, NULL, true, '2022-06-02', true, 22.00, 9, 1, NULL, NULL, 1, NULL, 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (33, 2, '2022-06-19 14:48:06.909732', 9, NULL, true, '2022-06-02', true, 2.00, 10, 1, NULL, NULL, 1, NULL, 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (34, 2, '2022-06-19 14:48:10.296115', 9, NULL, true, '2022-06-02', true, 42.00, 11, 1, NULL, NULL, 1, NULL, 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (35, 5, '2022-06-19 14:48:14.017', 9, NULL, true, '2022-06-02', true, 30.00, 12, 1, NULL, NULL, 1, NULL, 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (36, 5, '2022-06-19 14:48:17.236893', 9, NULL, true, '2022-06-02', true, 22.00, 13, 1, NULL, NULL, 1, NULL, 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (18, 5, '2022-06-17 22:10:31.100396', 9, NULL, true, '2022-06-02', true, 152.00, 14, 1, NULL, NULL, 1, NULL, 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (12, 5, '2022-06-17 00:00:00', 9, NULL, true, '2022-06-03', true, 110.50, 15, 1, NULL, NULL, 1, NULL, 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (15, 5, '2022-06-17 00:00:00', 9, NULL, true, '2022-06-03', true, 111.00, 16, 1, NULL, NULL, 1, NULL, 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (13, 5, '2022-06-17 00:00:00', 9, NULL, true, '2022-06-03', true, 82.00, 17, 1, NULL, NULL, 1, NULL, 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (38, 3, '2022-06-19 21:20:37.985616', 2, NULL, true, '2022-06-03', true, 182.00, 18, 1, NULL, NULL, 1, NULL, 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (39, 3, '2022-06-20 15:09:40.413555', 2, NULL, true, '2022-06-04', true, 144.50, 19, 1, NULL, NULL, 1, NULL, 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (40, 3, '2022-06-20 15:13:02.654453', 2, NULL, true, '2022-06-04', true, 113.00, 20, 1, NULL, NULL, 1, NULL, 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (41, 4, '2022-06-20 15:29:48.99632', 3, NULL, true, '2022-06-04', true, 185.50, 21, 1, NULL, NULL, 1, NULL, 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (46, 4, '2022-06-22 16:23:35.279555', 3, NULL, false, NULL, true, 224.50, 22, 1, NULL, NULL, 1, NULL, 1);
INSERT INTO public."Sale" OVERRIDING SYSTEM VALUE VALUES (42, 2, '2022-06-20 20:11:11.862395', 9, NULL, false, NULL, true, 76.00, 1, 1, NULL, NULL, 1, NULL, 1);


--
-- TOC entry 3518 (class 0 OID 19866)
-- Dependencies: 234
-- Data for Name: SaleDetail; Type: TABLE DATA; Schema: public; Owner: -
--

INSERT INTO public."SaleDetail" VALUES ('9db816fa-284e-46a1-985c-66b87fb7880d', 53, 13, 37.00, 1, 1, 37.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 1);
INSERT INTO public."SaleDetail" VALUES ('b31c8ed1-8964-484a-ae90-eae55ad02d49', 12, 1, 22.00, 1, 1, 22.00, NULL, NULL, NULL, true, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public."SaleDetail" VALUES ('8a4c14af-caad-4d76-bfd4-31ad90f27fd2', 12, 2, 22.00, 1, 3, 66.00, NULL, NULL, NULL, true, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public."SaleDetail" VALUES ('2b24ebaa-3d34-46c6-91b4-ebb3f2b90389', 12, 10, 45.00, 0.5, 1, 22.50, NULL, NULL, NULL, true, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public."SaleDetail" VALUES ('f1112bb0-09b5-45e4-82bb-ced5db5c1917', 13, 11, 37.00, 1, 1, 37.00, NULL, NULL, NULL, true, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public."SaleDetail" VALUES ('8c4bbcdc-16eb-49af-a473-bda8fc5490f2', 13, 10, 45.00, 1, 1, 45.00, NULL, NULL, NULL, true, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public."SaleDetail" VALUES ('9d4f0972-5187-4c86-a476-6541b374ee00', 15, 1, 22.00, 1, 1, 22.00, NULL, NULL, NULL, true, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public."SaleDetail" VALUES ('4dcc1ffe-bfee-4ed3-b181-43e7ede3ef41', 15, 2, 22.00, 1, 1, 22.00, NULL, NULL, NULL, true, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public."SaleDetail" VALUES ('a174db04-52bb-4320-b63e-a3bfe8aec6d1', 15, 3, 32.00, 1, 1, 32.00, NULL, NULL, NULL, true, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public."SaleDetail" VALUES ('72f13578-6de3-410e-b277-8c7097ae951a', 15, 4, 35.00, 1, 1, 35.00, NULL, NULL, NULL, true, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public."SaleDetail" VALUES ('5be9c538-1583-41c1-80f5-91e56c77fbf5', 55, 21, 20.00, 1, 1, 20.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 0);
INSERT INTO public."SaleDetail" VALUES ('2984459e-2047-4cab-9d94-0eaaefc9e1b5', 55, 21, 20.00, 1, 1, 20.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 1);
INSERT INTO public."SaleDetail" VALUES ('d57e263f-47ec-4b58-b6f3-a42bd3c3fa67', 18, 1, 22.00, 1, 3, 66.00, '-Bol Sos
  1 x Turşusuz
  1 x Patatessiz
  1 x Yeşilliksiz
', NULL, NULL, true, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public."SaleDetail" VALUES ('50c2c85a-44e2-4571-8a3b-087beefe4641', 18, 2, 22.00, 1, 1, 22.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public."SaleDetail" VALUES ('f3115029-0d7f-46a1-8b92-e9b173c78f9b', 18, 3, 32.00, 2, 1, 64.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public."SaleDetail" VALUES ('d008c7ae-3e32-4ab7-bdd3-82dc49e8a5f3', 55, 21, 20.00, 1, 1, 20.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 2);
INSERT INTO public."SaleDetail" VALUES ('f3f4bd15-4e63-4f3a-a0ae-16ec62ca5440', 55, 21, 20.00, 1, 1, 20.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 3);
INSERT INTO public."SaleDetail" VALUES ('a72d6e84-b1d2-4e03-9ac1-9fd48e88e415', 55, 28, 9.00, 1, 1, 9.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 4);
INSERT INTO public."SaleDetail" VALUES ('2f75c6a5-55c2-45a5-9197-8861194fc157', 25, 16, 38.00, 1, 1, 38.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public."SaleDetail" VALUES ('d583e5af-806b-4dcb-bdca-1fcaf0f0615b', 26, 20, 49.00, 1, 1, 49.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public."SaleDetail" VALUES ('d203f7ed-38a1-4621-9e84-f42b528224b4', 27, 24, 2.00, 1, 1, 2.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public."SaleDetail" VALUES ('04deb6a4-36a5-4443-ba27-57148384a933', 28, 17, 45.00, 1, 1, 45.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public."SaleDetail" VALUES ('5c40684e-97c4-429a-89e8-99f56bbfde23', 29, 2, 22.00, 1, 1, 22.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public."SaleDetail" VALUES ('15e02640-9ee6-45dd-b6a6-4f1eb2bc43d6', 31, 2, 22.00, 1, 1, 22.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public."SaleDetail" VALUES ('132f6ddb-5bcf-4b3b-956a-bacf182a19af', 33, 41, 2.00, 1, 1, 2.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public."SaleDetail" VALUES ('ebea1c2f-ea43-43ef-a5b7-75e9dddd219b', 34, 9, 42.00, 1, 1, 42.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public."SaleDetail" VALUES ('4c358aab-22c5-487f-920b-aa8013a4662e', 35, 8, 30.00, 1, 1, 30.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public."SaleDetail" VALUES ('b591fe65-8675-41b5-b3c8-5b9b339d8f8d', 36, 2, 22.00, 1, 1, 22.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public."SaleDetail" VALUES ('b6269594-4ef3-4852-ac03-96ab15bd4021', 24, 24, 2.00, 1, 1, 2.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 0);
INSERT INTO public."SaleDetail" VALUES ('c3aecb52-7529-41ce-8cf2-a18fd06b4f4c', 24, 1, 22.00, 1, 1, 22.00, '-Bol Sos
', NULL, NULL, true, NULL, 'Bol Sos', NULL, NULL, 1);
INSERT INTO public."SaleDetail" VALUES ('14c20623-d967-4fb0-990b-6f7ce4cb66e7', 38, 1, 22.00, 1, 1, 22.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public."SaleDetail" VALUES ('119765f7-7500-4e6c-be9d-974ccf7f9864', 38, 12, 32.00, 1, 5, 160.00, '-Sossuz
  1 x Bol Turşu
  1 x Patatessiz
  1 x Az Domates
', NULL, NULL, true, NULL, 'Az Domates', NULL, NULL, NULL);
INSERT INTO public."SaleDetail" VALUES ('939f7548-d0c8-4222-a1c9-44fa2f2fa7d2', 39, 1, 22.00, 1, 5, 110.00, '-Mayonezsiz
  1 x Bol Mayonez
  1 x Az Mayonez
  1 x İlave Domates
', NULL, NULL, true, NULL, 'İlave Domates', NULL, NULL, NULL);
INSERT INTO public."SaleDetail" VALUES ('22139e8d-6837-4f2c-9603-695d8245c65b', 39, 6, 24.00, 1, 1, 24.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public."SaleDetail" VALUES ('8f2dcdde-61f5-46f0-a042-fe2f303d916e', 39, 43, 4.50, 1, 1, 4.50, '', NULL, NULL, true, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public."SaleDetail" VALUES ('2b7bacb3-ce22-401d-9abb-652c4dafaa07', 39, 42, 6.00, 1, 1, 6.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public."SaleDetail" VALUES ('6ce6bdf1-de40-4278-9ae4-ba1bb8bbaa09', 40, 11, 37.00, 1, 3, 111.00, '-Bol Sos
  1 x Mayonezsiz
  1 x Turşusuz
  1 x Patatessiz
', NULL, NULL, true, 'Mayonezsiz', 'Bol Sos', 'Turşusuz', 'Patatessiz', NULL);
INSERT INTO public."SaleDetail" VALUES ('c57dbe60-62e3-4317-a576-bb857f677aa7', 40, 41, 2.00, 1, 1, 2.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, NULL);
INSERT INTO public."SaleDetail" VALUES ('d2a548e7-b13e-4bde-800c-40d18974c43b', 41, 2, 22.00, 1, 4, 88.00, '-Sossuz
  1 x Bol Mayonez
  1 x Bol Turşu
  1 x Bol Patates
', NULL, NULL, true, 'Bol Mayonez', 'Sossuz', 'Bol Turşu', 'Bol Patates', 0);
INSERT INTO public."SaleDetail" VALUES ('e7c9d387-2ef0-4034-9241-dfe9c1774a22', 41, 43, 4.50, 1, 1, 4.50, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 1);
INSERT INTO public."SaleDetail" VALUES ('3a06e2d4-bc52-49be-a4b2-7fd6ec1a7857', 41, 11, 37.00, 1, 1, 37.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 2);
INSERT INTO public."SaleDetail" VALUES ('e3f8947f-49b7-4c40-b47e-869b4334c4a8', 41, 30, 9.00, 1, 1, 9.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 3);
INSERT INTO public."SaleDetail" VALUES ('08a25614-4177-4098-817c-827d5ef89f7f', 41, 13, 37.00, 1, 1, 37.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 4);
INSERT INTO public."SaleDetail" VALUES ('910de146-b844-4772-a954-ada2295cf848', 41, 23, 10.00, 1, 1, 10.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 5);
INSERT INTO public."SaleDetail" VALUES ('8c6a4a5c-25b5-4ade-ace7-e5328d424c11', 42, 1, 22.00, 1, 1, 22.00, '-Bol Patates
', NULL, NULL, true, NULL, 'Bol Patates', NULL, NULL, 0);
INSERT INTO public."SaleDetail" VALUES ('ead66e82-7e37-41b5-9c90-439ae3a106d6', 42, 2, 22.00, 1, 1, 22.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 1);
INSERT INTO public."SaleDetail" VALUES ('f295f2f9-8681-4b27-a881-850dd47c666c', 42, 3, 32.00, 1, 1, 32.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 2);
INSERT INTO public."SaleDetail" VALUES ('8a21f23c-89ff-4c2c-84c5-4e50c206baa7', 24, 26, 9.00, 1, 2, 18.00, '  1 x max
', NULL, NULL, true, 'max', NULL, NULL, NULL, 2);
INSERT INTO public."SaleDetail" VALUES ('3599b897-45f5-4542-8ef1-679deb1bce74', 24, 29, 9.00, 1, 1, 9.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 3);
INSERT INTO public."SaleDetail" VALUES ('a9436743-6e2d-4c8f-b70f-2bba6ac832fa', 24, 30, 9.00, 1, 1, 9.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 4);
INSERT INTO public."SaleDetail" VALUES ('ccd0861c-095b-4e3e-9f92-6310fad3e74f', 24, 41, 2.00, 1, 1, 2.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 5);
INSERT INTO public."SaleDetail" VALUES ('2d3f2068-eef7-4a25-b642-44068ece90ae', 56, 12, 32.00, 1, 1, 32.00, '-Bol Sos
', NULL, NULL, true, NULL, 'Bol Sos', NULL, NULL, 0);
INSERT INTO public."SaleDetail" VALUES ('9a15a181-a3ce-46c7-8745-42a63269df99', 56, 44, 4.00, 1, 1, 4.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 1);
INSERT INTO public."SaleDetail" VALUES ('97668b83-2f3c-4cf9-bad8-327d75bd77df', 56, 14, 34.00, 1, 12, 408.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 2);
INSERT INTO public."SaleDetail" VALUES ('7cce1142-1b9a-4f00-9224-f1c1643c9ec7', 57, 1, 22.00, 1, 1, 22.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 1);
INSERT INTO public."SaleDetail" VALUES ('65a07e2a-289b-47d7-b3d6-95b67043292d', 57, 2, 22.00, 1, 1, 22.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 2);
INSERT INTO public."SaleDetail" VALUES ('dcb66b66-18b6-4bc9-87c8-a2cf9dfb8cf0', 57, 3, 32.00, 1, 1, 32.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 3);
INSERT INTO public."SaleDetail" VALUES ('3583356d-c814-4a77-a05e-63a9d96acd39', 57, 4, 35.00, 1, 1, 35.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 4);
INSERT INTO public."SaleDetail" VALUES ('ab5e63f9-3e5d-492d-8c7e-edd5f5a2bd8b', 58, 8, 30.00, 1, 1, 30.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 1);
INSERT INTO public."SaleDetail" VALUES ('c2992224-7a38-492e-a560-e33e03da325b', 58, 17, 45.00, 1, 1, 45.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 2);
INSERT INTO public."SaleDetail" VALUES ('7d3f6068-bdbe-40a5-8bc8-564ad1513645', 58, 12, 32.00, 1, 1, 32.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 3);
INSERT INTO public."SaleDetail" VALUES ('cb4c4e23-5d70-4141-9fb8-17f15c514ad8', 59, 44, 4.00, 1, 1, 4.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 1);
INSERT INTO public."SaleDetail" VALUES ('05e67ae8-79a2-4412-8b2e-29311ec63622', 59, 43, 4.50, 1, 1, 4.50, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 2);
INSERT INTO public."SaleDetail" VALUES ('b5fc03b3-978d-4099-ad00-3b9f86d50a13', 30, 1, 22.00, 1, 1, 22.00, '-Sossuz
', NULL, NULL, true, NULL, 'Sossuz', NULL, NULL, 0);
INSERT INTO public."SaleDetail" VALUES ('87f2db91-6835-4d31-adfe-816ffb8262e3', 45, 4, 35.00, 1, 1, 35.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 1);
INSERT INTO public."SaleDetail" VALUES ('870052c3-50a9-4e15-b62f-0e9087bcdafa', 45, 7, 30.00, 1, 1, 30.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 2);
INSERT INTO public."SaleDetail" VALUES ('8c072836-6b89-4e13-8ea7-28759188cee1', 45, 12, 32.00, 1, 1, 32.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 3);
INSERT INTO public."SaleDetail" VALUES ('18c4d6f4-d71f-4533-8860-2ca758922e6d', 46, 1, 22.00, 1, 1, 22.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 1);
INSERT INTO public."SaleDetail" VALUES ('f4e8ecc0-cf53-4c47-8d1d-d02fb229754d', 46, 2, 22.00, 1, 1, 22.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 2);
INSERT INTO public."SaleDetail" VALUES ('4f0f90b6-31eb-4e73-b5a8-5940261dfb62', 46, 3, 32.00, 1, 1, 32.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 3);
INSERT INTO public."SaleDetail" VALUES ('1206c543-9efd-44fc-9152-2b0ee07a95f2', 46, 4, 35.00, 1, 1, 35.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 4);
INSERT INTO public."SaleDetail" VALUES ('60de3297-9eed-4b15-acb6-7266a2f828dd', 46, 5, 27.00, 1, 1, 27.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 5);
INSERT INTO public."SaleDetail" VALUES ('2459811c-54ad-4f70-b0ac-38eded6d4b4b', 46, 6, 24.00, 1, 1, 24.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 6);
INSERT INTO public."SaleDetail" VALUES ('7f0e67fa-defc-403b-b043-56aebc1c35ab', 46, 13, 37.00, 1, 1, 37.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 7);
INSERT INTO public."SaleDetail" VALUES ('75a8d447-d9f6-4f53-b302-4b662a1fac1e', 46, 44, 4.00, 1, 1, 4.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 8);
INSERT INTO public."SaleDetail" VALUES ('472b9c7c-4081-41bd-99c1-30b98eaea9b7', 46, 43, 4.50, 1, 1, 4.50, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 9);
INSERT INTO public."SaleDetail" VALUES ('e981d2c1-7215-4f85-b0c2-aa42fb15999e', 46, 42, 6.00, 1, 1, 6.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 10);
INSERT INTO public."SaleDetail" VALUES ('c10ee566-56b5-4913-a731-fe20e35504b1', 46, 41, 2.00, 1, 1, 2.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 11);
INSERT INTO public."SaleDetail" VALUES ('42f4f2c4-247b-4637-b883-4d79ef070838', 46, 30, 9.00, 1, 1, 9.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 12);
INSERT INTO public."SaleDetail" VALUES ('a137266a-5e8a-4d50-a338-a4ed287dfa75', 50, 1, 22.00, 1, 4, 88.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 0);
INSERT INTO public."SaleDetail" VALUES ('9ed4d828-d3ad-4fe5-8ff0-52958fc1200a', 50, 26, 9.00, 1, 1, 9.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 1);
INSERT INTO public."SaleDetail" VALUES ('72924dd3-46a5-43fc-9fc0-9564db44cde4', 51, 26, 9.00, 1, 1, 9.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 0);
INSERT INTO public."SaleDetail" VALUES ('7da23812-e01d-40a5-a4fb-a277d0986bbb', 51, 29, 9.00, 1, 1, 9.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 1);
INSERT INTO public."SaleDetail" VALUES ('855a2156-d2ca-4c21-92a4-ba2215f6ac44', 51, 30, 9.00, 1, 1, 9.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 2);
INSERT INTO public."SaleDetail" VALUES ('46449643-af54-4ed5-9bcf-188bb6d32818', 51, 41, 2.00, 1, 1, 2.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 3);
INSERT INTO public."SaleDetail" VALUES ('3d5be269-bd0c-4c60-80eb-8059a32ea720', 51, 4, 35.00, 1, 1, 35.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 4);
INSERT INTO public."SaleDetail" VALUES ('a3369cd2-6cf1-48ce-98e0-0583038a0109', 52, 7, 30.00, 1, 1, 30.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 0);
INSERT INTO public."SaleDetail" VALUES ('6c864d61-2d74-4f83-aed6-eaf52f101801', 52, 8, 30.00, 1, 1, 30.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 1);
INSERT INTO public."SaleDetail" VALUES ('b489da90-2146-4e75-b69f-e067fe71e7e3', 52, 9, 42.00, 1, 1, 42.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 2);
INSERT INTO public."SaleDetail" VALUES ('95ec3426-5846-4046-b51a-a46966fbc648', 52, 1, 22.00, 1, 1, 22.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 3);
INSERT INTO public."SaleDetail" VALUES ('6f3c097c-1f0f-4fcd-8e3a-7615fdfdb918', 59, 42, 6.00, 1, 1, 6.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 3);
INSERT INTO public."SaleDetail" VALUES ('0bf2807d-a0b2-4ff5-acf2-cabb585cf7f5', 59, 41, 2.00, 1, 1, 2.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 4);
INSERT INTO public."SaleDetail" VALUES ('346bf438-c7e2-4f13-a29c-3cf6def6b294', 59, 30, 9.00, 1, 1, 9.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 5);
INSERT INTO public."SaleDetail" VALUES ('827fa972-a4bd-4c13-bcc7-adb221c0057c', 59, 13, 37.00, 1, 1, 37.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 6);
INSERT INTO public."SaleDetail" VALUES ('98de56ac-e25d-425f-821b-ddd9f7e379c1', 59, 12, 32.00, 1, 1, 32.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 7);
INSERT INTO public."SaleDetail" VALUES ('27191501-c7da-4796-99f7-476f8451628a', 59, 11, 37.00, 1, 1, 37.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 8);
INSERT INTO public."SaleDetail" VALUES ('cf18ee72-943c-4db1-9ad8-ecd98e9eca3b', 59, 10, 45.00, 1, 1, 45.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 9);
INSERT INTO public."SaleDetail" VALUES ('965dd0fc-ca17-4ab0-aef5-331ddf6304ee', 61, 1, 22.00, 1, 1, 22.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 1);
INSERT INTO public."SaleDetail" VALUES ('20465e88-e2f0-41f4-ab0a-f8e6c0dc5fe8', 61, 6, 24.00, 1, 1, 24.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 2);
INSERT INTO public."SaleDetail" VALUES ('5407dc67-0c07-4fc2-8f2b-73180c3644bd', 61, 9, 42.00, 1, 1, 42.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 3);
INSERT INTO public."SaleDetail" VALUES ('d6390769-b889-4843-9694-21a6e4f2ee56', 61, 18, 42.00, 1, 1, 42.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 4);
INSERT INTO public."SaleDetail" VALUES ('8e68bfcb-77e9-4ac8-a51e-9d843ff914ae', 61, 10, 45.00, 1, 1, 45.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 5);
INSERT INTO public."SaleDetail" VALUES ('9f64de1b-1ee2-4504-89a9-6592385b910a', 61, 11, 37.00, 1, 1, 37.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 6);
INSERT INTO public."SaleDetail" VALUES ('f9d33f14-60e2-4588-bfe4-169efeeebe43', 62, 1, 22.00, 1, 1, 22.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 1);
INSERT INTO public."SaleDetail" VALUES ('71b9d613-7d1b-48c6-8ffd-b308d11f9560', 62, 7, 30.00, 1, 1, 30.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 2);
INSERT INTO public."SaleDetail" VALUES ('48514cd8-9201-4354-82c3-ac04f7e02d7f', 62, 12, 32.00, 1, 1, 32.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 3);
INSERT INTO public."SaleDetail" VALUES ('9f4470c2-fece-4fea-80b4-8c3d97007f62', 62, 17, 45.00, 1, 1, 45.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 4);
INSERT INTO public."SaleDetail" VALUES ('88cbc7bd-2024-47e8-bab4-8e146e8d3d41', 62, 8, 30.00, 1, 1, 30.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 5);
INSERT INTO public."SaleDetail" VALUES ('a601f44c-2269-4875-b940-a61c9abc26f2', 62, 11, 37.00, 1, 1, 37.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 6);
INSERT INTO public."SaleDetail" VALUES ('4b068f57-7000-4740-b4ff-f59a0cd245ab', 63, 26, 9.00, 1, 1, 9.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 1);
INSERT INTO public."SaleDetail" VALUES ('72decd56-c9e4-4975-8804-c7e152050f87', 63, 29, 9.00, 1, 1, 9.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 2);
INSERT INTO public."SaleDetail" VALUES ('e15b55cd-712c-4a13-a368-b61e49d28048', 63, 30, 9.00, 1, 1, 9.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 3);
INSERT INTO public."SaleDetail" VALUES ('b288a1f6-06e2-4b24-9135-03989ca0e3bb', 63, 41, 2.00, 1, 1, 2.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 4);
INSERT INTO public."SaleDetail" VALUES ('fa2a3fa7-5c44-4659-a110-41e482d011c6', 63, 42, 6.00, 1, 1, 6.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 5);
INSERT INTO public."SaleDetail" VALUES ('6f7b2fcd-11c8-4e58-8c12-7d9b83e2722c', 63, 43, 4.50, 1, 1, 4.50, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 6);
INSERT INTO public."SaleDetail" VALUES ('dfa92d96-bf30-4897-bfb4-e2f318e8f563', 63, 12, 32.00, 1, 1, 32.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 7);
INSERT INTO public."SaleDetail" VALUES ('a5c29702-babe-407f-a4a2-85fc45ff5d13', 63, 11, 37.00, 1, 1, 37.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 8);
INSERT INTO public."SaleDetail" VALUES ('b71f214d-8ce9-4f5f-b3ee-532b3598e7f7', 63, 10, 45.00, 1, 1, 45.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 9);
INSERT INTO public."SaleDetail" VALUES ('514687b5-b8b4-4fe3-a674-b91f76e7599d', 64, 7, 30.00, 1, 1, 30.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 1);
INSERT INTO public."SaleDetail" VALUES ('a507655b-551d-4443-b0a1-a6ee6f5371d6', 64, 8, 30.00, 1, 1, 30.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 2);
INSERT INTO public."SaleDetail" VALUES ('b4ba6275-a448-4413-831c-844e2c6075a4', 64, 17, 45.00, 1, 1, 45.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 3);
INSERT INTO public."SaleDetail" VALUES ('1d5f82ed-6d07-4dae-90f2-20a7d813da88', 64, 12, 32.00, 1, 1, 32.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 4);
INSERT INTO public."SaleDetail" VALUES ('fc3205ee-f690-4057-94ab-bda27266eb19', 64, 11, 37.00, 1, 1, 37.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 5);
INSERT INTO public."SaleDetail" VALUES ('a4ae6335-9a31-497c-8af7-520fe8a6aa83', 65, 8, 30.00, 1, 1, 30.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 1);
INSERT INTO public."SaleDetail" VALUES ('9b95c8e5-68d0-4897-a38b-11acc2793c5b', 65, 7, 30.00, 1, 1, 30.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 2);
INSERT INTO public."SaleDetail" VALUES ('c39949c3-8a60-4578-93c7-be12f006db3d', 65, 12, 32.00, 1, 1, 32.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 3);
INSERT INTO public."SaleDetail" VALUES ('6eef3033-f739-4799-b0f4-64ddc1a103de', 65, 17, 45.00, 1, 1, 45.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 4);
INSERT INTO public."SaleDetail" VALUES ('39da4578-3aea-4c10-a401-622f14a3d011', 66, 7, 30.00, 1, 1, 30.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 1);
INSERT INTO public."SaleDetail" VALUES ('2cb4ce96-62ef-4cf0-aa26-d6b0cbc0d528', 66, 8, 30.00, 1, 1, 30.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 2);
INSERT INTO public."SaleDetail" VALUES ('a0488c8a-32fe-40db-a9a7-89b0896123f5', 66, 17, 45.00, 1, 1, 45.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 3);
INSERT INTO public."SaleDetail" VALUES ('170fa50a-cc39-4054-a444-05efb06e2ba2', 66, 12, 32.00, 1, 1, 32.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 4);
INSERT INTO public."SaleDetail" VALUES ('e2da233c-06fd-45e3-9184-797145fea1b0', 66, 11, 37.00, 1, 1, 37.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 5);
INSERT INTO public."SaleDetail" VALUES ('6e46fa0c-8cdd-430a-824b-bcffc5fac56c', 67, 1, 22.00, 1, 1, 22.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 1);
INSERT INTO public."SaleDetail" VALUES ('60edff0f-b3cf-452a-a0e4-a82c187f6fda', 67, 3, 32.00, 1, 1, 32.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 2);
INSERT INTO public."SaleDetail" VALUES ('b8d97ff1-cacc-463b-93d1-5c431d6defc8', 67, 8, 30.00, 1, 1, 30.00, '-Mayonezsiz, Turşusuz
  1 x Domatessiz, Bol Domates
', NULL, NULL, true, 'Domatessiz
Bol Domates', 'Mayonezsiz
Turşusuz', NULL, NULL, 3);
INSERT INTO public."SaleDetail" VALUES ('0e93e7e2-5858-4e33-8757-102faf071573', 68, 1, 22.00, 1, 1, 22.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 1);
INSERT INTO public."SaleDetail" VALUES ('592778e6-7528-4e62-80bd-43f8559f70ab', 68, 14, 34.00, 1, 1, 34.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 2);
INSERT INTO public."SaleDetail" VALUES ('7c586b63-fee1-491b-813c-e4bc68a2c5d7', 69, 4, 35.00, 1, 1, 35.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 1);
INSERT INTO public."SaleDetail" VALUES ('6cd68083-8bcf-4c6b-995a-accb299faa91', 69, 7, 30.00, 1, 1, 30.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 2);
INSERT INTO public."SaleDetail" VALUES ('65d73035-1c31-4590-bbeb-215274ff1156', 69, 12, 32.00, 1, 1, 32.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 3);
INSERT INTO public."SaleDetail" VALUES ('40cd0fd1-c425-452f-b73b-f7e28d05a6aa', 70, 5, 27.00, 1, 1, 27.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 1);
INSERT INTO public."SaleDetail" VALUES ('7646fc75-94f2-499e-96d7-c840df0f75cb', 70, 8, 30.00, 1, 1, 30.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 2);
INSERT INTO public."SaleDetail" VALUES ('73285799-7760-4f73-9234-b91c3046dc2f', 71, 44, 4.00, 1, 1, 4.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 1);
INSERT INTO public."SaleDetail" VALUES ('1a913b01-50fa-45b4-b67b-c0a123bc96b3', 72, 13, 37.00, 1, 1, 37.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 1);
INSERT INTO public."SaleDetail" VALUES ('36a5b0eb-ba0d-441c-a8c7-fd10f375511a', 72, 12, 32.00, 1, 1, 32.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 2);
INSERT INTO public."SaleDetail" VALUES ('5a7b1b16-5bd9-414f-9a70-99f9de1191a1', 73, 11, 37.00, 1, 1, 37.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 1);
INSERT INTO public."SaleDetail" VALUES ('bf0f41d6-48e3-43b3-b117-f624c62d2e85', 73, 6, 24.00, 1, 3, 72.00, '-Sossuz
  1 x Turşusuz
  1 x Domatessiz
  1 x Bol Yeşillik
', NULL, NULL, true, 'Turşusuz', 'Sossuz', 'Domatessiz', 'Bol Yeşillik', 2);
INSERT INTO public."SaleDetail" VALUES ('c5578447-ea45-481c-bd2b-d33344576a4c', 74, 1, 22.00, 1, 1, 22.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 1);
INSERT INTO public."SaleDetail" VALUES ('ed61a984-ce30-4179-bc10-76ca997e4cac', 74, 2, 22.00, 1, 1, 22.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 2);
INSERT INTO public."SaleDetail" VALUES ('4fefeca4-fa09-442a-8a40-78689441c8f5', 75, 5, 27.00, 1, 1, 27.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 1);
INSERT INTO public."SaleDetail" VALUES ('7070faaa-15fe-44be-ae4e-71c414c1955b', 75, 8, 30.00, 1, 1, 30.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 2);
INSERT INTO public."SaleDetail" VALUES ('53340dc6-70f0-4c2d-a8cb-90053c28927b', 75, 17, 45.00, 1, 1, 45.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 3);
INSERT INTO public."SaleDetail" VALUES ('7bdb7765-031e-4b57-8787-0ef785b1b2d8', 76, 5, 27.00, 1, 1, 27.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 1);
INSERT INTO public."SaleDetail" VALUES ('e70389d9-996b-4c81-82fc-2ed0871c8d54', 76, 8, 30.00, 1, 1, 30.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 2);
INSERT INTO public."SaleDetail" VALUES ('e870e9bf-3c23-46d0-9872-5b247ac99805', 76, 17, 45.00, 1, 1, 45.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 3);
INSERT INTO public."SaleDetail" VALUES ('3db47ea1-5979-485f-968d-d8b498defbbd', 77, 5, 27.00, 1, 1, 27.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 1);
INSERT INTO public."SaleDetail" VALUES ('686db3a2-e2a0-40b4-99df-00078dad96d7', 77, 8, 30.00, 1, 1, 30.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 2);
INSERT INTO public."SaleDetail" VALUES ('e200d636-736d-4467-9b48-9c014fe51823', 77, 17, 45.00, 1, 1, 45.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 3);
INSERT INTO public."SaleDetail" VALUES ('30246ff8-0d11-42f1-92b7-9d058893f4fd', 78, 41, 2.00, 1, 1, 2.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 1);
INSERT INTO public."SaleDetail" VALUES ('3cfe9eed-18f9-4d64-be47-050229c57a82', 78, 23, 9.00, 1, 1, 9.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 2);
INSERT INTO public."SaleDetail" VALUES ('8e8700e8-32e7-4013-8954-ad2978ff363b', 78, 21, 20.00, 1, 1, 20.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 3);
INSERT INTO public."SaleDetail" VALUES ('3368d6d5-af31-4ab9-a6aa-2e51cee1345e', 79, 44, 4.00, 1, 1, 4.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 1);
INSERT INTO public."SaleDetail" VALUES ('3e0e21b5-4f73-4741-951e-104ef7f50403', 79, 21, 20.00, 1, 1, 20.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 2);
INSERT INTO public."SaleDetail" VALUES ('af8b860d-f336-4c1b-a3d4-e1303041505b', 80, 25, 4.00, 1, 1, 4.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 1);
INSERT INTO public."SaleDetail" VALUES ('33bd97f9-f304-4542-9aee-5c85ef933132', 81, 25, 4.00, 1, 1, 4.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 1);
INSERT INTO public."SaleDetail" VALUES ('9c6e836e-38cc-4d92-85cd-6f9423d6c67c', 82, 43, 4.50, 1, 1, 4.50, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 1);
INSERT INTO public."SaleDetail" VALUES ('fd776bda-2233-43c8-bed5-3016b8d0ab05', 82, 44, 4.00, 1, 1, 4.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 2);
INSERT INTO public."SaleDetail" VALUES ('adcc575d-a9e3-435c-bff3-fe66371b6d59', 83, 7, 30.00, 1, 1, 30.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 1);
INSERT INTO public."SaleDetail" VALUES ('947f34f0-2673-4876-8ede-7ef79a92a27e', 84, 11, 37.00, 1, 1, 37.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 1);
INSERT INTO public."SaleDetail" VALUES ('849d3b2e-3b16-4ce6-a169-2c7b6a72cc37', 85, 17, 45.00, 1, 1, 45.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 1);
INSERT INTO public."SaleDetail" VALUES ('0ccaf7c3-6271-490a-adcc-f9a64722fb37', 86, 5, 27.00, 1, 1, 27.00, '', NULL, NULL, true, NULL, NULL, NULL, NULL, 1);


--
-- TOC entry 3527 (class 0 OID 20015)
-- Dependencies: 243
-- Data for Name: SaleType; Type: TABLE DATA; Schema: public; Owner: -
--

INSERT INTO public."SaleType" OVERRIDING SYSTEM VALUE VALUES (1, 'İçeri Satışı', true, NULL);
INSERT INTO public."SaleType" OVERRIDING SYSTEM VALUE VALUES (2, 'Paket Satışı', true, NULL);
INSERT INTO public."SaleType" OVERRIDING SYSTEM VALUE VALUES (3, 'Telefon Satışı', true, 2);
INSERT INTO public."SaleType" OVERRIDING SYSTEM VALUE VALUES (4, 'Yemek Sepeti', true, 2);
INSERT INTO public."SaleType" OVERRIDING SYSTEM VALUE VALUES (5, 'Getir Yemek', true, 2);
INSERT INTO public."SaleType" OVERRIDING SYSTEM VALUE VALUES (6, 'Trendyol Yemek', true, 2);


--
-- TOC entry 3508 (class 0 OID 19687)
-- Dependencies: 224
-- Data for Name: Supplier; Type: TABLE DATA; Schema: public; Owner: -
--



--
-- TOC entry 3514 (class 0 OID 19754)
-- Dependencies: 230
-- Data for Name: SupplierFirmType; Type: TABLE DATA; Schema: public; Owner: -
--



--
-- TOC entry 3504 (class 0 OID 19665)
-- Dependencies: 220
-- Data for Name: User; Type: TABLE DATA; Schema: public; Owner: -
--

INSERT INTO public."User" OVERRIDING SYSTEM VALUE VALUES (9, 'M.Emin', 'BOZKAYA', 'Bozki', '5550079086', 'wingman152@icloud.com', 'MTExMQ==', true, '2022-06-23', NULL);
INSERT INTO public."User" OVERRIDING SYSTEM VALUE VALUES (2, 'emirim', 'demir', 'dede', '5485698547', 'e@boz.com', 'MTExMQ==', true, '2022-04-04', '2022-04-11');
INSERT INTO public."User" OVERRIDING SYSTEM VALUE VALUES (3, 'fluent', 'validation', 'fluval', '4569854521', 'f@val.com', 'MTExMQ==', true, '2022-04-11', '2022-04-11');
INSERT INTO public."User" OVERRIDING SYSTEM VALUE VALUES (5, 'sfdffsd', 'dfgdfgd', 'jhjljhljlk', '2584715698', 's@v.com', 'MTExMQ==', true, '2022-04-11', '2022-04-11');
INSERT INTO public."User" OVERRIDING SYSTEM VALUE VALUES (7, 'deneme', 'dedem', 'ddgh', '1236985478', 'e@boz.com', 'MTExMQ==', false, '2022-04-07', '2022-04-16');
INSERT INTO public."User" OVERRIDING SYSTEM VALUE VALUES (4, 'dfhgghg', 'fgh', 'sdfg', '1234567895', 'e@boz.com', 'MTExMQ==', false, '2022-04-08', '2022-06-04');
INSERT INTO public."User" OVERRIDING SYSTEM VALUE VALUES (8, 'gamze', 'günay', 'ggünay', '5485698547', 'e@boz.com', 'MTExMQ==', true, '2022-06-17', NULL);
INSERT INTO public."User" OVERRIDING SYSTEM VALUE VALUES (1, 'DoesntExist', 'NoPerson', 'DummyPerson', '1111111111', '1@111.com', 'MTExMQ==', true, '2022-04-01', '2022-06-17');
INSERT INTO public."User" OVERRIDING SYSTEM VALUE VALUES (6, 'memin', 'boz', 'bozki', '1234567891', 'e@boz.com', 'MTExMQ==', false, '2022-04-01', '2022-07-29');


--
-- TOC entry 3510 (class 0 OID 19706)
-- Dependencies: 226
-- Data for Name: UserBranchAuthority; Type: TABLE DATA; Schema: public; Owner: -
--

INSERT INTO public."UserBranchAuthority" OVERRIDING SYSTEM VALUE VALUES (3, 2, 3, 6, true);
INSERT INTO public."UserBranchAuthority" OVERRIDING SYSTEM VALUE VALUES (4, 5, 4, 2, true);
INSERT INTO public."UserBranchAuthority" OVERRIDING SYSTEM VALUE VALUES (5, 3, 4, 1, true);
INSERT INTO public."UserBranchAuthority" OVERRIDING SYSTEM VALUE VALUES (6, 4, 1, 5, true);
INSERT INTO public."UserBranchAuthority" OVERRIDING SYSTEM VALUE VALUES (1, 9, 2, 3, true);
INSERT INTO public."UserBranchAuthority" OVERRIDING SYSTEM VALUE VALUES (2, 9, 5, 4, true);
INSERT INTO public."UserBranchAuthority" OVERRIDING SYSTEM VALUE VALUES (7, 6, 2, 3, true);


--
-- TOC entry 3494 (class 0 OID 19621)
-- Dependencies: 210
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: -
--

INSERT INTO public."__EFMigrationsHistory" VALUES ('20220420200154_RCMblazorFirstMig', '6.0.2');
INSERT INTO public."__EFMigrationsHistory" VALUES ('20220421201504_BranchProductPrice', '6.0.2');
INSERT INTO public."__EFMigrationsHistory" VALUES ('20220421222336_SaleAndSaleDetail', '6.0.2');
INSERT INTO public."__EFMigrationsHistory" VALUES ('20220422123802_AddColorCodeToProduct', '6.0.2');
INSERT INTO public."__EFMigrationsHistory" VALUES ('20220422203612_ProductMenuList', '6.0.2');
INSERT INTO public."__EFMigrationsHistory" VALUES ('20220427194608_addProductSaleNote', '6.0.2');
INSERT INTO public."__EFMigrationsHistory" VALUES ('20220428122123_ProductSaleNoteCategory', '6.0.2');
INSERT INTO public."__EFMigrationsHistory" VALUES ('20220617130104_addTotalPriceToSale', '6.0.2');
INSERT INTO public."__EFMigrationsHistory" VALUES ('20220619140843_AddingProductNotesToSaleDetailTable', '6.0.2');
INSERT INTO public."__EFMigrationsHistory" VALUES ('20220620121852_addBillOrderColumnToSaleDetail', '6.0.2');
INSERT INTO public."__EFMigrationsHistory" VALUES ('20220622120004_ChangeDateOnlyToDateTimeInSaleTable', '6.0.2');
INSERT INTO public."__EFMigrationsHistory" VALUES ('20220622120633_ChangeDateTimeToDateInSaleTable', '6.0.2');
INSERT INTO public."__EFMigrationsHistory" VALUES ('20220624151151_Change_Sale_and_Add_SaleType', '6.0.2');
INSERT INTO public."__EFMigrationsHistory" VALUES ('20220624152604_Add_TopSTId_To_SaleType', '6.0.2');
INSERT INTO public."__EFMigrationsHistory" VALUES ('20220624153337_defineMappingOnSaleTypesForeignKey', '6.0.2');


--
-- TOC entry 3535 (class 0 OID 0)
-- Dependencies: 211
-- Name: AuthorityType_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public."AuthorityType_Id_seq"', 8, true);


--
-- TOC entry 3536 (class 0 OID 0)
-- Dependencies: 227
-- Name: BranchSupplier_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public."BranchSupplier_Id_seq"', 1, false);


--
-- TOC entry 3537 (class 0 OID 0)
-- Dependencies: 213
-- Name: Branch_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public."Branch_Id_seq"', 6, true);


--
-- TOC entry 3538 (class 0 OID 0)
-- Dependencies: 215
-- Name: FirmType_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public."FirmType_Id_seq"', 1, false);


--
-- TOC entry 3539 (class 0 OID 0)
-- Dependencies: 217
-- Name: ProductCategory_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public."ProductCategory_Id_seq"', 29, true);


--
-- TOC entry 3540 (class 0 OID 0)
-- Dependencies: 235
-- Name: ProductMenuList_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public."ProductMenuList_Id_seq"', 4, true);


--
-- TOC entry 3541 (class 0 OID 0)
-- Dependencies: 239
-- Name: ProductSaleNoteCategory_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public."ProductSaleNoteCategory_Id_seq"', 6, true);


--
-- TOC entry 3542 (class 0 OID 0)
-- Dependencies: 237
-- Name: ProductSaleNote_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public."ProductSaleNote_Id_seq"', 38, true);


--
-- TOC entry 3543 (class 0 OID 0)
-- Dependencies: 221
-- Name: Product_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public."Product_Id_seq"', 59, true);


--
-- TOC entry 3544 (class 0 OID 0)
-- Dependencies: 242
-- Name: SaleType_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public."SaleType_Id_seq"', 6, true);


--
-- TOC entry 3545 (class 0 OID 0)
-- Dependencies: 241
-- Name: Sale_DailyBillOrder_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public."Sale_DailyBillOrder_seq"', 23, true);


--
-- TOC entry 3546 (class 0 OID 0)
-- Dependencies: 232
-- Name: Sale_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public."Sale_Id_seq"', 86, true);


--
-- TOC entry 3547 (class 0 OID 0)
-- Dependencies: 229
-- Name: SupplierFirmType_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public."SupplierFirmType_Id_seq"', 1, false);


--
-- TOC entry 3548 (class 0 OID 0)
-- Dependencies: 223
-- Name: Supplier_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public."Supplier_Id_seq"', 1, false);


--
-- TOC entry 3549 (class 0 OID 0)
-- Dependencies: 225
-- Name: UserBranchAuthority_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public."UserBranchAuthority_Id_seq"', 7, true);


--
-- TOC entry 3550 (class 0 OID 0)
-- Dependencies: 219
-- Name: User_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public."User_Id_seq"', 9, true);


--
-- TOC entry 3306 (class 2606 OID 19801)
-- Name: BranchProductPrice PK_BranchProductPrice; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."BranchProductPrice"
    ADD CONSTRAINT "PK_BranchProductPrice" PRIMARY KEY ("BId", "PId");


--
-- TOC entry 3321 (class 2606 OID 19917)
-- Name: ProductSaleNote PK_ProductSaleNote; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."ProductSaleNote"
    ADD CONSTRAINT "PK_ProductSaleNote" PRIMARY KEY ("Id");


--
-- TOC entry 3323 (class 2606 OID 19955)
-- Name: ProductSaleNoteCategory PK_ProductSaleNoteCategory; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."ProductSaleNoteCategory"
    ADD CONSTRAINT "PK_ProductSaleNoteCategory" PRIMARY KEY ("Id");


--
-- TOC entry 3311 (class 2606 OID 19855)
-- Name: Sale PK_Sale; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Sale"
    ADD CONSTRAINT "PK_Sale" PRIMARY KEY ("Id");


--
-- TOC entry 3316 (class 2606 OID 19873)
-- Name: SaleDetail PK_SaleDetail; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."SaleDetail"
    ADD CONSTRAINT "PK_SaleDetail" PRIMARY KEY ("Id");


--
-- TOC entry 3326 (class 2606 OID 20021)
-- Name: SaleType PK_SaleType; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."SaleType"
    ADD CONSTRAINT "PK_SaleType" PRIMARY KEY ("Id");


--
-- TOC entry 3267 (class 2606 OID 19625)
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


--
-- TOC entry 3269 (class 2606 OID 19633)
-- Name: AuthorityType pk_AuthorityType_id; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."AuthorityType"
    ADD CONSTRAINT "pk_AuthorityType_id" PRIMARY KEY ("Id");


--
-- TOC entry 3297 (class 2606 OID 19732)
-- Name: BranchSupplier pk_BranchSupplier_id; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."BranchSupplier"
    ADD CONSTRAINT "pk_BranchSupplier_id" PRIMARY KEY ("Id");


--
-- TOC entry 3271 (class 2606 OID 19642)
-- Name: Branch pk_Branch_id; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Branch"
    ADD CONSTRAINT "pk_Branch_id" PRIMARY KEY ("Id");


--
-- TOC entry 3273 (class 2606 OID 19650)
-- Name: FirmType pk_FirmType_id; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."FirmType"
    ADD CONSTRAINT "pk_FirmType_id" PRIMARY KEY ("Id");


--
-- TOC entry 3276 (class 2606 OID 19658)
-- Name: ProductCategory pk_ProductCategory_id; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."ProductCategory"
    ADD CONSTRAINT "pk_ProductCategory_id" PRIMARY KEY ("Id");


--
-- TOC entry 3318 (class 2606 OID 19902)
-- Name: ProductMenuList pk_ProductMenuList_id; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."ProductMenuList"
    ADD CONSTRAINT "pk_ProductMenuList_id" PRIMARY KEY ("Id");


--
-- TOC entry 3282 (class 2606 OID 19680)
-- Name: Product pk_Product_id; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Product"
    ADD CONSTRAINT "pk_Product_id" PRIMARY KEY ("Id");


--
-- TOC entry 3303 (class 2606 OID 19759)
-- Name: SupplierFirmType pk_SupplierFirmType_id; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."SupplierFirmType"
    ADD CONSTRAINT "pk_SupplierFirmType_id" PRIMARY KEY ("Id");


--
-- TOC entry 3286 (class 2606 OID 19694)
-- Name: Supplier pk_Supplier_id; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Supplier"
    ADD CONSTRAINT "pk_Supplier_id" PRIMARY KEY ("Id");


--
-- TOC entry 3291 (class 2606 OID 19710)
-- Name: UserBranchAuthority pk_UserBranchAuthority_id; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."UserBranchAuthority"
    ADD CONSTRAINT "pk_UserBranchAuthority_id" PRIMARY KEY ("Id");


--
-- TOC entry 3278 (class 2606 OID 19672)
-- Name: User pk_User_id; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."User"
    ADD CONSTRAINT "pk_User_id" PRIMARY KEY ("Id");


--
-- TOC entry 3304 (class 1259 OID 19812)
-- Name: IX_BranchProductPrice_PId; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_BranchProductPrice_PId" ON public."BranchProductPrice" USING btree ("PId");


--
-- TOC entry 3292 (class 1259 OID 19780)
-- Name: IX_BranchSupplier_BId; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_BranchSupplier_BId" ON public."BranchSupplier" USING btree ("BId");


--
-- TOC entry 3293 (class 1259 OID 19781)
-- Name: IX_BranchSupplier_CreatedBy; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_BranchSupplier_CreatedBy" ON public."BranchSupplier" USING btree ("CreatedBy");


--
-- TOC entry 3294 (class 1259 OID 19782)
-- Name: IX_BranchSupplier_ModifiedBy; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_BranchSupplier_ModifiedBy" ON public."BranchSupplier" USING btree ("ModifiedBy");


--
-- TOC entry 3295 (class 1259 OID 19783)
-- Name: IX_BranchSupplier_SpId; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_BranchSupplier_SpId" ON public."BranchSupplier" USING btree ("SpId");


--
-- TOC entry 3274 (class 1259 OID 19785)
-- Name: IX_ProductCategory_TopCatId; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_ProductCategory_TopCatId" ON public."ProductCategory" USING btree ("TopCatId");


--
-- TOC entry 3319 (class 1259 OID 19956)
-- Name: IX_ProductSaleNote_NoteCat; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_ProductSaleNote_NoteCat" ON public."ProductSaleNote" USING btree ("NoteCat");


--
-- TOC entry 3279 (class 1259 OID 19784)
-- Name: IX_Product_CatId; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_Product_CatId" ON public."Product" USING btree ("CatId");


--
-- TOC entry 3280 (class 1259 OID 19903)
-- Name: IX_Product_MenuListId; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_Product_MenuListId" ON public."Product" USING btree ("MenuListId");


--
-- TOC entry 3312 (class 1259 OID 19891)
-- Name: IX_SaleDetail_ModifiedBy; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_SaleDetail_ModifiedBy" ON public."SaleDetail" USING btree ("ModifiedBy");


--
-- TOC entry 3313 (class 1259 OID 19892)
-- Name: IX_SaleDetail_PId; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_SaleDetail_PId" ON public."SaleDetail" USING btree ("PId");


--
-- TOC entry 3314 (class 1259 OID 19893)
-- Name: IX_SaleDetail_SId; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_SaleDetail_SId" ON public."SaleDetail" USING btree ("SId");


--
-- TOC entry 3324 (class 1259 OID 20051)
-- Name: IX_SaleType_TopSTId; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_SaleType_TopSTId" ON public."SaleType" USING btree ("TopSTId");


--
-- TOC entry 3307 (class 1259 OID 19889)
-- Name: IX_Sale_BId; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_Sale_BId" ON public."Sale" USING btree ("BId");


--
-- TOC entry 3308 (class 1259 OID 20022)
-- Name: IX_Sale_DeletedBy; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_Sale_DeletedBy" ON public."Sale" USING btree ("DeletedBy");


--
-- TOC entry 3309 (class 1259 OID 20023)
-- Name: IX_Sale_STId; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_Sale_STId" ON public."Sale" USING btree ("STId");


--
-- TOC entry 3298 (class 1259 OID 19788)
-- Name: IX_SupplierFirmType_CreatedBy; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_SupplierFirmType_CreatedBy" ON public."SupplierFirmType" USING btree ("CreatedBy");


--
-- TOC entry 3299 (class 1259 OID 19789)
-- Name: IX_SupplierFirmType_FtId; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_SupplierFirmType_FtId" ON public."SupplierFirmType" USING btree ("FtId");


--
-- TOC entry 3300 (class 1259 OID 19790)
-- Name: IX_SupplierFirmType_ModifiedBy; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_SupplierFirmType_ModifiedBy" ON public."SupplierFirmType" USING btree ("ModifiedBy");


--
-- TOC entry 3301 (class 1259 OID 19791)
-- Name: IX_SupplierFirmType_SpId; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_SupplierFirmType_SpId" ON public."SupplierFirmType" USING btree ("SpId");


--
-- TOC entry 3283 (class 1259 OID 19786)
-- Name: IX_Supplier_CreatedBy; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_Supplier_CreatedBy" ON public."Supplier" USING btree ("CreatedBy");


--
-- TOC entry 3284 (class 1259 OID 19787)
-- Name: IX_Supplier_ModifiedBy; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_Supplier_ModifiedBy" ON public."Supplier" USING btree ("ModifiedBy");


--
-- TOC entry 3287 (class 1259 OID 19792)
-- Name: IX_UserBranchAuthority_ATId; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_UserBranchAuthority_ATId" ON public."UserBranchAuthority" USING btree ("ATId");


--
-- TOC entry 3288 (class 1259 OID 19793)
-- Name: IX_UserBranchAuthority_BId; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_UserBranchAuthority_BId" ON public."UserBranchAuthority" USING btree ("BId");


--
-- TOC entry 3289 (class 1259 OID 19794)
-- Name: IX_UserBranchAuthority_UId; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_UserBranchAuthority_UId" ON public."UserBranchAuthority" USING btree ("UId");


--
-- TOC entry 3343 (class 2606 OID 19802)
-- Name: BranchProductPrice FK_BranchProductPrice_Branch_BId; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."BranchProductPrice"
    ADD CONSTRAINT "FK_BranchProductPrice_Branch_BId" FOREIGN KEY ("BId") REFERENCES public."Branch"("Id") ON DELETE CASCADE;


--
-- TOC entry 3344 (class 2606 OID 19807)
-- Name: BranchProductPrice FK_BranchProductPrice_Product_PId; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."BranchProductPrice"
    ADD CONSTRAINT "FK_BranchProductPrice_Product_PId" FOREIGN KEY ("PId") REFERENCES public."Product"("Id") ON DELETE CASCADE;


--
-- TOC entry 3335 (class 2606 OID 19733)
-- Name: BranchSupplier FK_BranchSupplier_Branch_BId; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."BranchSupplier"
    ADD CONSTRAINT "FK_BranchSupplier_Branch_BId" FOREIGN KEY ("BId") REFERENCES public."Branch"("Id") ON DELETE CASCADE;


--
-- TOC entry 3336 (class 2606 OID 19738)
-- Name: BranchSupplier FK_BranchSupplier_Supplier_SpId; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."BranchSupplier"
    ADD CONSTRAINT "FK_BranchSupplier_Supplier_SpId" FOREIGN KEY ("SpId") REFERENCES public."Supplier"("Id") ON DELETE CASCADE;


--
-- TOC entry 3337 (class 2606 OID 19743)
-- Name: BranchSupplier FK_BranchSupplier_User_CreatedBy; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."BranchSupplier"
    ADD CONSTRAINT "FK_BranchSupplier_User_CreatedBy" FOREIGN KEY ("CreatedBy") REFERENCES public."User"("Id") ON DELETE CASCADE;


--
-- TOC entry 3338 (class 2606 OID 19748)
-- Name: BranchSupplier FK_BranchSupplier_User_ModifiedBy; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."BranchSupplier"
    ADD CONSTRAINT "FK_BranchSupplier_User_ModifiedBy" FOREIGN KEY ("ModifiedBy") REFERENCES public."User"("Id") ON DELETE CASCADE;


--
-- TOC entry 3353 (class 2606 OID 19957)
-- Name: ProductSaleNote FK_ProductSaleNote_ProductSaleNoteCategory_NoteCat; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."ProductSaleNote"
    ADD CONSTRAINT "FK_ProductSaleNote_ProductSaleNoteCategory_NoteCat" FOREIGN KEY ("NoteCat") REFERENCES public."ProductSaleNoteCategory"("Id") ON DELETE CASCADE;


--
-- TOC entry 3328 (class 2606 OID 19681)
-- Name: Product FK_Product_ProductCategory_CatId; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Product"
    ADD CONSTRAINT "FK_Product_ProductCategory_CatId" FOREIGN KEY ("CatId") REFERENCES public."ProductCategory"("Id") ON DELETE CASCADE;


--
-- TOC entry 3329 (class 2606 OID 19904)
-- Name: Product FK_Product_ProductMenuList_MenuListId; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Product"
    ADD CONSTRAINT "FK_Product_ProductMenuList_MenuListId" FOREIGN KEY ("MenuListId") REFERENCES public."ProductMenuList"("Id") ON DELETE CASCADE;


--
-- TOC entry 3350 (class 2606 OID 19874)
-- Name: SaleDetail FK_SaleDetail_Product_PId; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."SaleDetail"
    ADD CONSTRAINT "FK_SaleDetail_Product_PId" FOREIGN KEY ("PId") REFERENCES public."Product"("Id") ON DELETE CASCADE;


--
-- TOC entry 3351 (class 2606 OID 19879)
-- Name: SaleDetail FK_SaleDetail_Sale_SId; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."SaleDetail"
    ADD CONSTRAINT "FK_SaleDetail_Sale_SId" FOREIGN KEY ("SId") REFERENCES public."Sale"("Id") ON DELETE CASCADE;


--
-- TOC entry 3352 (class 2606 OID 19884)
-- Name: SaleDetail FK_SaleDetail_User_ModifiedBy; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."SaleDetail"
    ADD CONSTRAINT "FK_SaleDetail_User_ModifiedBy" FOREIGN KEY ("ModifiedBy") REFERENCES public."User"("Id") ON DELETE CASCADE;


--
-- TOC entry 3345 (class 2606 OID 19856)
-- Name: Sale FK_Sale_Branch_BId; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Sale"
    ADD CONSTRAINT "FK_Sale_Branch_BId" FOREIGN KEY ("BId") REFERENCES public."Branch"("Id") ON DELETE CASCADE;


--
-- TOC entry 3346 (class 2606 OID 20024)
-- Name: Sale FK_Sale_SaleType_STId; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Sale"
    ADD CONSTRAINT "FK_Sale_SaleType_STId" FOREIGN KEY ("STId") REFERENCES public."SaleType"("Id") ON DELETE CASCADE;


--
-- TOC entry 3347 (class 2606 OID 20029)
-- Name: Sale FK_Sale_User_DeletedBy; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Sale"
    ADD CONSTRAINT "FK_Sale_User_DeletedBy" FOREIGN KEY ("DeletedBy") REFERENCES public."User"("Id") ON DELETE CASCADE;


--
-- TOC entry 3348 (class 2606 OID 20034)
-- Name: Sale FK_Sale_User_ModifiedBy; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Sale"
    ADD CONSTRAINT "FK_Sale_User_ModifiedBy" FOREIGN KEY ("ModifiedBy") REFERENCES public."User"("Id") ON DELETE CASCADE;


--
-- TOC entry 3349 (class 2606 OID 20046)
-- Name: Sale FK_Sale_User_UId; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Sale"
    ADD CONSTRAINT "FK_Sale_User_UId" FOREIGN KEY ("UId") REFERENCES public."User"("Id") ON DELETE CASCADE;


--
-- TOC entry 3327 (class 2606 OID 19659)
-- Name: ProductCategory FK_SubProductCategories_TopProduct_TopCatId; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."ProductCategory"
    ADD CONSTRAINT "FK_SubProductCategories_TopProduct_TopCatId" FOREIGN KEY ("TopCatId") REFERENCES public."ProductCategory"("Id") ON DELETE CASCADE;


--
-- TOC entry 3354 (class 2606 OID 20052)
-- Name: SaleType FK_SubSubSaleTypes_TopSaleType_TopSTId; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."SaleType"
    ADD CONSTRAINT "FK_SubSubSaleTypes_TopSaleType_TopSTId" FOREIGN KEY ("TopSTId") REFERENCES public."SaleType"("Id") ON DELETE CASCADE;


--
-- TOC entry 3339 (class 2606 OID 19760)
-- Name: SupplierFirmType FK_SupplierFirmType_FirmType_FtId; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."SupplierFirmType"
    ADD CONSTRAINT "FK_SupplierFirmType_FirmType_FtId" FOREIGN KEY ("FtId") REFERENCES public."FirmType"("Id") ON DELETE CASCADE;


--
-- TOC entry 3340 (class 2606 OID 19765)
-- Name: SupplierFirmType FK_SupplierFirmType_Supplier_SpId; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."SupplierFirmType"
    ADD CONSTRAINT "FK_SupplierFirmType_Supplier_SpId" FOREIGN KEY ("SpId") REFERENCES public."Supplier"("Id") ON DELETE CASCADE;


--
-- TOC entry 3341 (class 2606 OID 19770)
-- Name: SupplierFirmType FK_SupplierFirmType_User_CreatedBy; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."SupplierFirmType"
    ADD CONSTRAINT "FK_SupplierFirmType_User_CreatedBy" FOREIGN KEY ("CreatedBy") REFERENCES public."User"("Id") ON DELETE CASCADE;


--
-- TOC entry 3342 (class 2606 OID 19775)
-- Name: SupplierFirmType FK_SupplierFirmType_User_ModifiedBy; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."SupplierFirmType"
    ADD CONSTRAINT "FK_SupplierFirmType_User_ModifiedBy" FOREIGN KEY ("ModifiedBy") REFERENCES public."User"("Id") ON DELETE CASCADE;


--
-- TOC entry 3330 (class 2606 OID 19695)
-- Name: Supplier FK_Supplier_User_CreatedBy; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Supplier"
    ADD CONSTRAINT "FK_Supplier_User_CreatedBy" FOREIGN KEY ("CreatedBy") REFERENCES public."User"("Id") ON DELETE CASCADE;


--
-- TOC entry 3331 (class 2606 OID 19700)
-- Name: Supplier FK_Supplier_User_ModifiedBy; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Supplier"
    ADD CONSTRAINT "FK_Supplier_User_ModifiedBy" FOREIGN KEY ("ModifiedBy") REFERENCES public."User"("Id") ON DELETE CASCADE;


--
-- TOC entry 3332 (class 2606 OID 19711)
-- Name: UserBranchAuthority FK_UserBranchAuthoritiy_AuthorityType_ATId; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."UserBranchAuthority"
    ADD CONSTRAINT "FK_UserBranchAuthoritiy_AuthorityType_ATId" FOREIGN KEY ("ATId") REFERENCES public."AuthorityType"("Id") ON DELETE CASCADE;


--
-- TOC entry 3333 (class 2606 OID 19716)
-- Name: UserBranchAuthority FK_UserBranchAuthoritiy_Branch_BId; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."UserBranchAuthority"
    ADD CONSTRAINT "FK_UserBranchAuthoritiy_Branch_BId" FOREIGN KEY ("BId") REFERENCES public."Branch"("Id") ON DELETE CASCADE;


--
-- TOC entry 3334 (class 2606 OID 19721)
-- Name: UserBranchAuthority FK_UserBranchAuthoritiy_User_UId; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."UserBranchAuthority"
    ADD CONSTRAINT "FK_UserBranchAuthoritiy_User_UId" FOREIGN KEY ("UId") REFERENCES public."User"("Id") ON DELETE CASCADE;


-- Completed on 2022-09-12 13:37:38

--
-- PostgreSQL database dump complete
--

