# RottenMango
프로세스 통계 및 최적화 서비스


  <img src="https://github.com/hyeseok/RottenMango/blob/RottenMango.Step4/Images/rm1.png"/>
  <h4>언어 : C# <br/>
      사용 툴 : Visual Studio <br/>
      데이터베이스 : Microsoft SQL Server <br/>
      사용 기술 : 데이터베이스와 Visual Studio(Winform)를 Entities Framework 기술로 연동하여 프로젝트를 진행하였음.
  </h4>

  <img src="https://github.com/hyeseok/RottenMango/blob/RottenMango.Step4/Images/rm2.png"/> 
  <h4>C#에서 제공하는 CPU, Memory의 사용량을 1초 단위로 
데이터베이스에 업데이트를 하여 하루, 한달, 1년 등 통계치를
구하는 로직을 구성하였음. </br>
 추가적으로 구현해야 되는 내용으로는 1초 마다 저장되는 
데이터베이스는 하루 기준으로 저장하는데 데이터베이스에 많은
양이 저장되면 과부하가 걸리는 현상을 방지하기 위해 하루 기준
으로 초기화를 시키는 로직을 구현할 생각임. 
  </h4>
  
<div style="overflow:left">
  <img src="https://github.com/hyeseok/RottenMango/blob/RottenMango.Step4/Images/rm3.png"/> 
  <img src="https://github.com/hyeseok/RottenMango/blob/RottenMango.Step4/Images/rm4.png"/>
</div>
  </br>
  <img src="https://github.com/hyeseok/RottenMango/blob/RottenMango.Step4/Images/rm5.png"/>
  <h3><시연 화면 및 기술 설명></h2>
  <h4>
 UI는 Metro Framework를 사용하여 아래의 그림과 같이 구성하였음. </br> 
 기존의 작업관리자와는 달리 컴퓨터를 잘 모르는 사람도 보기 쉽게 배치하였고, 
 통계치를 구하여 불필요하게 프로세스를 차지하는 프로그램을 자동으로 찾아주어 
 종료할 수 있도록 유도하는 로직도 추후 업데이트 할 예정임 
 </br>
 보완할 점 : 저희가 제작한 프로젝트가 1초마다 CPU와 메모리를 찾아내는 과정에서의 사용되는
CPU점유율이 높아져서 좋은 의도로 만든 프로그램이 불필요한 프로세스를 차지하는 역효과를 보이는 
현상이 있기 때문에 이 부분은 추후 어떻게 보완할지 팀원들과의 의견을 조합하여 해결해 나갈 예정임.
  </h4>
