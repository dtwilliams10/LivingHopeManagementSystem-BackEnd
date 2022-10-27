--delete from public.system_names -- where id < 13;

select *
from system_names;

insert into system_names
select *
from (
        values (1, 'Youth System'),
            (2, 'First Touch System'),
            (3, 'Second Touch System'),
            (4, 'Specialized Ministries System'),
            (5, 'Childrens System'),
            (6, 'Administrative System'),
            (7, 'Campus Preservation System'),
            (8, 'Christian Development System')
            (9, 'Hispanic System'),
            (10, 'Media System'),
            (11, 'Worship System'),
            (12, 'Creative System')
    ) as data ("name")
where not exists (
        select *
        from system_names
        where data = system_names
    );

select *
from system_names;