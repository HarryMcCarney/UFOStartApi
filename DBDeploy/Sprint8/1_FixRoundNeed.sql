-- removing duplicate needs in round and adding unique cnostyraint to prevent further additions

declare @needs table (id int)
insert @needs
select min(id)
from round_need
group by round_id, need_id


delete from dbo.round_need_tag
where round_need_id not in 
(
select id from @needs
)

delete from dbo.expert_round_need
where round_need_id not in 
(
select id from @needs
)


delete 
from round_need
where id not in 
(
select id from @needs
)

create unique index uix_round_need_round_need on round_need (round_id, need_id)

-- removing duplicate slugs in round and adding unique cnostyraint to prevent further additions

declare @needs table (id int)
insert @needs
select min(id)
from round_need
group by round_id, slug


delete from dbo.round_need_tag
where round_need_id not in 
(
select id from @needs
)

delete from dbo.expert_round_need
where round_need_id not in 
(
select id from @needs
)


delete 
from round_need
where id not in 
(
select id from @needs
)

create unique index uix_round_need_round_slug on round_need (round_id, slug)


