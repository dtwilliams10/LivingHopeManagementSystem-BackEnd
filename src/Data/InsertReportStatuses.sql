--delete from public.system_report_status; -- where id < 15;

select * from system_report_status;

insert into system_report_status
select *
from (values 
	  (1, 'Inactive'), 
	  (2, 'Draft'),
	  (3, 'Submitted to Team Lead'),
	  (4, 'Rejected by Team Lead'),
	  (5, 'Approved by Team Lead'),
	  (6, 'Submitted to System Director'),
	  (7, 'Rejected by System Director'),
	  (8, 'Approved by System Director'),
	  (9, 'Submitted to Administrative Pastor'),
	  (10, 'Rejected by Administrative Pastor'),
	  (11, 'Approved by Administrative Pastor'),
	  (12, 'Submitted to Senior Pastor'),
	  (13, 'Rejected by Senior Pastor'),
	  (14, 'Approved by Senior Pastor')
	  ) as data ("name")
where not exists (select *
                  from system_report_status
                  where data = system_report_status);
				  
select * from system_report_status;