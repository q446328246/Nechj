package com.adobe.protocols.dict.events
{
	import flash.events.Event;
	import com.adobe.protocols.dict.Dict;

	public partial class ConnectedEvent extends Event
	{
		public function ConnectedEvent()
		{
			super(Dict.CONNECTED);
		}
		
	}
}