
  
CREATE Procedure [dbo].[p.objectModel.Event.LoadAll]  
(  
 @event_id int  
)  
AS  
  
select  
 [event].title,  
 [event].description,  
 [eventType].display [eventTypeDisplay],  
 [eventType].item_pk [eventTypeID],  
 [eventType].enabled [eventTypeEnabled],  
 [eventType].code [eventTypeCode],  
 [eventType].sort [eventTypeSort],  
 active = CASE WHEN [event].retired=1 THEN 0 ELSE 1 END,  
 ec.dimensions,  
 ec.standards  
from  
 [event]  WITH (NOLOCK)  
 inner join [escworks.item] [eventType]  WITH (NOLOCK) on [eventType].item_pk = [event].[eventtype_id]  
 LEFT join [event.cube] ec on ec.obj_id = [event].obj_id  
where  
 [event].[obj_id] = @event_id  
  
select   
 [item].item_pk,  
 [item].display,  
 [item].enabled,  
 [item].sort,  
 [item].code  
from [event.multi.audience] [multiTable]  WITH (NOLOCK)  
 inner join [escworks.item] [item]  WITH (NOLOCK) on [multiTable].itm_id = [item].item_pk  
where  
 [multiTable].obj_id = @event_id  
  
  
select   
 [item].item_pk,  
 [item].display,  
 [item].enabled,  
 [item].sort,  
 [item].code  
from [event.multi.subjects] [multiTable]  WITH (NOLOCK)  
 inner join [escworks.item] [item]  WITH (NOLOCK) on [multiTable].itm_id = [item].item_pk  
where  
 [multiTable].obj_id = @event_id  
  
  
  
  
  
  