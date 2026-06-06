CREATE TABLE master.user_details(
	user_id character varying(36) NOT NULL,
	user_name character varying(64) NOT NULL,
	project_id character varying(36) NOT NULL, //foreign_key
	reporting_to character varying(36) NOT NuLL,
	CONSTRAINT pk_user_details_id PRIMARY KEY (user_id, user_name)
);

CREATE TABLE master.project_details(
	project_id character varying(36) NOT NULL,
	project_name character varying(64) NOT NULL,
	project_start_date timestamp,
	project_end_date timestamp,
CONSTRAINT pk_project_details_id PRIMARY KEY (project_id, project_name)
)

CREATE TABLE master.task_details(
	task_id character varying(36) NOT NULL,
	project_id character varying(36) NOT NuLL, //foreign_key
	task_name character varying(64),
	user_name character varying(64) NOT NULL,
	task_description character varying(256) NOT NULL,
	is_active boolean NOT NULL,
	created_by character varying(256) NOT NULL,
	created_time timestamp NOT NULL,
	updated_by character varying(256),
	updated_time timestamp,
	task_status character varying(64) NOT NULL,
	is_deleted boolean,
	del_dtimes timestamp,
	CONSTRAINT pk_task_details_id PRIMARY KEY (task_id, task_name)
);


