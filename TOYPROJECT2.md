# 토이 프로젝트

## WPF MVVM 패턴 활용

### MVVM 패턴 개요

- MVC 패턴의 확장
    - C++, C# Winforms 예전 MVC 따로 사용
    - 팀으로 개발할 때 디자인 작업, 개발 작업 분리 공백을 줄이고자
    - 유지보수 시 구분된 레이어만 수정하면 되는 장점
    - 단일 개발보다 구현이 쉽지 않음

- MVVM - Model - View - ViewModel
    - MVC 패턴과의 차이점 - 대문이 Controller 대신인 ViewModel이 아니고 `View`가 대문이다
    - View에서 동작의 처리를 시작, 이벤트 핸들러가 모두 사라짐
    - View에 해당하는 xaml, cs 파일에는 아무런 로직이 안들어감(디자이너가 로직을 생각지 말것)
    - 버튼, 키보드 이벤트가 모두 ViewModel로 넘어감 -> Command


![alt text](image-263.png)

### MVVM 초간단 예시

- Models, Views, ViewModels 폴더(네임스페이스) 생성