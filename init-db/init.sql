--
-- PostgreSQL database dump
--

-- Dumped from database version 16.9
-- Dumped by pg_dump version 16.9

-- Started on 2025-07-20 00:20:01

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
-- TOC entry 6 (class 2615 OID 17689)
-- Name: dairy; Type: SCHEMA; Schema: -; Owner: -
--

CREATE SCHEMA dairy;


SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 223 (class 1259 OID 17769)
-- Name: client; Type: TABLE; Schema: dairy; Owner: -
--

CREATE TABLE dairy.client (
    id integer NOT NULL,
    name character varying(25) NOT NULL,
    contact_number character varying(20),
    email character varying(100),
    address text,
    is_deleted boolean DEFAULT false,
    created_at timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    modified_at timestamp without time zone
);


--
-- TOC entry 222 (class 1259 OID 17768)
-- Name: client_id_seq; Type: SEQUENCE; Schema: dairy; Owner: -
--

CREATE SEQUENCE dairy.client_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 4955 (class 0 OID 0)
-- Dependencies: 222
-- Name: client_id_seq; Type: SEQUENCE OWNED BY; Schema: dairy; Owner: -
--

ALTER SEQUENCE dairy.client_id_seq OWNED BY dairy.client.id;


--
-- TOC entry 227 (class 1259 OID 17800)
-- Name: client_order; Type: TABLE; Schema: dairy; Owner: -
--

CREATE TABLE dairy.client_order (
    id integer NOT NULL,
    client_id integer NOT NULL,
    product_id integer NOT NULL,
    quantity integer NOT NULL,
    total_amount numeric(10,2) NOT NULL,
    is_deleted boolean DEFAULT false,
    created_at timestamp without time zone DEFAULT CURRENT_TIMESTAMP
);


--
-- TOC entry 226 (class 1259 OID 17799)
-- Name: client_order_id_seq; Type: SEQUENCE; Schema: dairy; Owner: -
--

CREATE SEQUENCE dairy.client_order_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 4956 (class 0 OID 0)
-- Dependencies: 226
-- Name: client_order_id_seq; Type: SEQUENCE OWNED BY; Schema: dairy; Owner: -
--

ALTER SEQUENCE dairy.client_order_id_seq OWNED BY dairy.client_order.id;


--
-- TOC entry 219 (class 1259 OID 17745)
-- Name: inventory; Type: TABLE; Schema: dairy; Owner: -
--

CREATE TABLE dairy.inventory (
    id integer NOT NULL,
    quantity integer NOT NULL,
    product_id integer NOT NULL,
    created_at timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    modified_at timestamp without time zone
);


--
-- TOC entry 218 (class 1259 OID 17744)
-- Name: inventory_id_seq; Type: SEQUENCE; Schema: dairy; Owner: -
--

CREATE SEQUENCE dairy.inventory_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 4957 (class 0 OID 0)
-- Dependencies: 218
-- Name: inventory_id_seq; Type: SEQUENCE OWNED BY; Schema: dairy; Owner: -
--

ALTER SEQUENCE dairy.inventory_id_seq OWNED BY dairy.inventory.id;


--
-- TOC entry 217 (class 1259 OID 17734)
-- Name: product; Type: TABLE; Schema: dairy; Owner: -
--

CREATE TABLE dairy.product (
    id integer NOT NULL,
    name character varying(200) NOT NULL,
    code character varying(10) NOT NULL,
    description text,
    price numeric(10,2) NOT NULL,
    is_deleted boolean DEFAULT false,
    created_at timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    modified_at timestamp without time zone
);


--
-- TOC entry 216 (class 1259 OID 17733)
-- Name: product_id_seq; Type: SEQUENCE; Schema: dairy; Owner: -
--

CREATE SEQUENCE dairy.product_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 4958 (class 0 OID 0)
-- Dependencies: 216
-- Name: product_id_seq; Type: SEQUENCE OWNED BY; Schema: dairy; Owner: -
--

ALTER SEQUENCE dairy.product_id_seq OWNED BY dairy.product.id;


--
-- TOC entry 221 (class 1259 OID 17758)
-- Name: vendor; Type: TABLE; Schema: dairy; Owner: -
--

CREATE TABLE dairy.vendor (
    id integer NOT NULL,
    name character varying(25) NOT NULL,
    contact_number character varying(20),
    email character varying(100),
    address text,
    is_deleted boolean DEFAULT false,
    created_at timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    modified_at timestamp without time zone
);


--
-- TOC entry 220 (class 1259 OID 17757)
-- Name: vendor_id_seq; Type: SEQUENCE; Schema: dairy; Owner: -
--

CREATE SEQUENCE dairy.vendor_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 4959 (class 0 OID 0)
-- Dependencies: 220
-- Name: vendor_id_seq; Type: SEQUENCE OWNED BY; Schema: dairy; Owner: -
--

ALTER SEQUENCE dairy.vendor_id_seq OWNED BY dairy.vendor.id;


--
-- TOC entry 225 (class 1259 OID 17781)
-- Name: vendor_supply; Type: TABLE; Schema: dairy; Owner: -
--

CREATE TABLE dairy.vendor_supply (
    id integer NOT NULL,
    vendor_id integer NOT NULL,
    product_id integer NOT NULL,
    quantity integer NOT NULL,
    total_amount numeric(10,2) NOT NULL,
    is_deleted boolean DEFAULT false,
    created_at timestamp without time zone DEFAULT CURRENT_TIMESTAMP
);


--
-- TOC entry 224 (class 1259 OID 17780)
-- Name: vendor_supply_id_seq; Type: SEQUENCE; Schema: dairy; Owner: -
--

CREATE SEQUENCE dairy.vendor_supply_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 4960 (class 0 OID 0)
-- Dependencies: 224
-- Name: vendor_supply_id_seq; Type: SEQUENCE OWNED BY; Schema: dairy; Owner: -
--

ALTER SEQUENCE dairy.vendor_supply_id_seq OWNED BY dairy.vendor_supply.id;


--
-- TOC entry 4769 (class 2604 OID 17772)
-- Name: client id; Type: DEFAULT; Schema: dairy; Owner: -
--

ALTER TABLE ONLY dairy.client ALTER COLUMN id SET DEFAULT nextval('dairy.client_id_seq'::regclass);


--
-- TOC entry 4775 (class 2604 OID 17803)
-- Name: client_order id; Type: DEFAULT; Schema: dairy; Owner: -
--

ALTER TABLE ONLY dairy.client_order ALTER COLUMN id SET DEFAULT nextval('dairy.client_order_id_seq'::regclass);


--
-- TOC entry 4764 (class 2604 OID 17748)
-- Name: inventory id; Type: DEFAULT; Schema: dairy; Owner: -
--

ALTER TABLE ONLY dairy.inventory ALTER COLUMN id SET DEFAULT nextval('dairy.inventory_id_seq'::regclass);


--
-- TOC entry 4761 (class 2604 OID 17737)
-- Name: product id; Type: DEFAULT; Schema: dairy; Owner: -
--

ALTER TABLE ONLY dairy.product ALTER COLUMN id SET DEFAULT nextval('dairy.product_id_seq'::regclass);


--
-- TOC entry 4766 (class 2604 OID 17761)
-- Name: vendor id; Type: DEFAULT; Schema: dairy; Owner: -
--

ALTER TABLE ONLY dairy.vendor ALTER COLUMN id SET DEFAULT nextval('dairy.vendor_id_seq'::regclass);


--
-- TOC entry 4772 (class 2604 OID 17784)
-- Name: vendor_supply id; Type: DEFAULT; Schema: dairy; Owner: -
--

ALTER TABLE ONLY dairy.vendor_supply ALTER COLUMN id SET DEFAULT nextval('dairy.vendor_supply_id_seq'::regclass);


--
-- TOC entry 4945 (class 0 OID 17769)
-- Dependencies: 223
-- Data for Name: client; Type: TABLE DATA; Schema: dairy; Owner: -
--



--
-- TOC entry 4949 (class 0 OID 17800)
-- Dependencies: 227
-- Data for Name: client_order; Type: TABLE DATA; Schema: dairy; Owner: -
--



--
-- TOC entry 4941 (class 0 OID 17745)
-- Dependencies: 219
-- Data for Name: inventory; Type: TABLE DATA; Schema: dairy; Owner: -
--



--
-- TOC entry 4939 (class 0 OID 17734)
-- Dependencies: 217
-- Data for Name: product; Type: TABLE DATA; Schema: dairy; Owner: -
--

INSERT INTO dairy.product VALUES (1, 'Cow Milk', 'CM1', 'Cow Milk', 65.00, false, '2025-07-05 22:45:39.019163', NULL);


--
-- TOC entry 4943 (class 0 OID 17758)
-- Dependencies: 221
-- Data for Name: vendor; Type: TABLE DATA; Schema: dairy; Owner: -
--



--
-- TOC entry 4947 (class 0 OID 17781)
-- Dependencies: 225
-- Data for Name: vendor_supply; Type: TABLE DATA; Schema: dairy; Owner: -
--



--
-- TOC entry 4961 (class 0 OID 0)
-- Dependencies: 222
-- Name: client_id_seq; Type: SEQUENCE SET; Schema: dairy; Owner: -
--

SELECT pg_catalog.setval('dairy.client_id_seq', 1, false);


--
-- TOC entry 4962 (class 0 OID 0)
-- Dependencies: 226
-- Name: client_order_id_seq; Type: SEQUENCE SET; Schema: dairy; Owner: -
--

SELECT pg_catalog.setval('dairy.client_order_id_seq', 1, false);


--
-- TOC entry 4963 (class 0 OID 0)
-- Dependencies: 218
-- Name: inventory_id_seq; Type: SEQUENCE SET; Schema: dairy; Owner: -
--

SELECT pg_catalog.setval('dairy.inventory_id_seq', 1, false);


--
-- TOC entry 4964 (class 0 OID 0)
-- Dependencies: 216
-- Name: product_id_seq; Type: SEQUENCE SET; Schema: dairy; Owner: -
--

SELECT pg_catalog.setval('dairy.product_id_seq', 1, false);


--
-- TOC entry 4965 (class 0 OID 0)
-- Dependencies: 220
-- Name: vendor_id_seq; Type: SEQUENCE SET; Schema: dairy; Owner: -
--

SELECT pg_catalog.setval('dairy.vendor_id_seq', 1, false);


--
-- TOC entry 4966 (class 0 OID 0)
-- Dependencies: 224
-- Name: vendor_supply_id_seq; Type: SEQUENCE SET; Schema: dairy; Owner: -
--

SELECT pg_catalog.setval('dairy.vendor_supply_id_seq', 1, false);


--
-- TOC entry 4789 (class 2606 OID 17807)
-- Name: client_order client_order_pkey; Type: CONSTRAINT; Schema: dairy; Owner: -
--

ALTER TABLE ONLY dairy.client_order
    ADD CONSTRAINT client_order_pkey PRIMARY KEY (id);


--
-- TOC entry 4785 (class 2606 OID 17778)
-- Name: client client_pkey; Type: CONSTRAINT; Schema: dairy; Owner: -
--

ALTER TABLE ONLY dairy.client
    ADD CONSTRAINT client_pkey PRIMARY KEY (id);


--
-- TOC entry 4781 (class 2606 OID 17751)
-- Name: inventory inventory_pkey; Type: CONSTRAINT; Schema: dairy; Owner: -
--

ALTER TABLE ONLY dairy.inventory
    ADD CONSTRAINT inventory_pkey PRIMARY KEY (id);


--
-- TOC entry 4779 (class 2606 OID 17743)
-- Name: product product_pkey; Type: CONSTRAINT; Schema: dairy; Owner: -
--

ALTER TABLE ONLY dairy.product
    ADD CONSTRAINT product_pkey PRIMARY KEY (id);


--
-- TOC entry 4783 (class 2606 OID 17767)
-- Name: vendor vendor_pkey; Type: CONSTRAINT; Schema: dairy; Owner: -
--

ALTER TABLE ONLY dairy.vendor
    ADD CONSTRAINT vendor_pkey PRIMARY KEY (id);


--
-- TOC entry 4787 (class 2606 OID 17788)
-- Name: vendor_supply vendor_supply_pkey; Type: CONSTRAINT; Schema: dairy; Owner: -
--

ALTER TABLE ONLY dairy.vendor_supply
    ADD CONSTRAINT vendor_supply_pkey PRIMARY KEY (id);


--
-- TOC entry 4793 (class 2606 OID 17808)
-- Name: client_order client_order_client_id_fkey; Type: FK CONSTRAINT; Schema: dairy; Owner: -
--

ALTER TABLE ONLY dairy.client_order
    ADD CONSTRAINT client_order_client_id_fkey FOREIGN KEY (client_id) REFERENCES dairy.client(id) ON DELETE CASCADE;


--
-- TOC entry 4794 (class 2606 OID 17813)
-- Name: client_order client_order_product_id_fkey; Type: FK CONSTRAINT; Schema: dairy; Owner: -
--

ALTER TABLE ONLY dairy.client_order
    ADD CONSTRAINT client_order_product_id_fkey FOREIGN KEY (product_id) REFERENCES dairy.product(id) ON DELETE CASCADE;


--
-- TOC entry 4790 (class 2606 OID 17752)
-- Name: inventory inventory_product_id_fkey; Type: FK CONSTRAINT; Schema: dairy; Owner: -
--

ALTER TABLE ONLY dairy.inventory
    ADD CONSTRAINT inventory_product_id_fkey FOREIGN KEY (product_id) REFERENCES dairy.product(id) ON DELETE CASCADE;


--
-- TOC entry 4791 (class 2606 OID 17794)
-- Name: vendor_supply vendor_supply_product_id_fkey; Type: FK CONSTRAINT; Schema: dairy; Owner: -
--

ALTER TABLE ONLY dairy.vendor_supply
    ADD CONSTRAINT vendor_supply_product_id_fkey FOREIGN KEY (product_id) REFERENCES dairy.product(id) ON DELETE CASCADE;


--
-- TOC entry 4792 (class 2606 OID 17789)
-- Name: vendor_supply vendor_supply_vendor_id_fkey; Type: FK CONSTRAINT; Schema: dairy; Owner: -
--

ALTER TABLE ONLY dairy.vendor_supply
    ADD CONSTRAINT vendor_supply_vendor_id_fkey FOREIGN KEY (vendor_id) REFERENCES dairy.vendor(id) ON DELETE CASCADE;


-- Completed on 2025-07-20 00:20:01

--
-- PostgreSQL database dump complete
--

