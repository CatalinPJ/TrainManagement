È
>C:\Users\jolde\Desktop\TrainManagement\Services\RouteFinder.cs
	namespace 	
Services
 
{ 
public 

class 
RouteFinder 
{		 
DatabaseContext

 
_context

  
;

  !
public 
RouteFinder 
( 
DatabaseContext *
databaseContext+ :
): ;
{ 	
_context 
= 
databaseContext &
;& '
} 	
public:: 
List:: 
<:: 
string:: 
>:: 
	GetTrains:: %
(::% &
int::& )

originCode::* 4
,::4 5
int::6 9
destinationCode::: I
)::I J
{;; 	
List<< 
<<< 
string<< 
><< 
nodes<< 
=<<  
new<<! $
List<<% )
<<<) *
string<<* 0
><<0 1
(<<1 2
)<<2 3
;<<3 4
returncc 
nodescc 
;cc 
}dd 	
}ee 
}ff 