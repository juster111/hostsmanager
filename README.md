# 윈도우 호스트 파일 관리자 #

>     windows/system32/drivers/etc/hosts 파일대신
>     직접 수정 적용/롤백할수 있는 프로그램 


윈도우 호스트파일을 특정 패턴으로 저장

초기화시 그 패턴을 호스트파일에서 삭제하는 구조


----------
ver 1.0 단순 파일 overwrite 구조 

추가 할 일

**문제:** 내부 dns 캐시와 브라우저 캐시로 실시간으로 hosts 변경이 적용안됨.

임시 proxy를 생성해 로컬에서 해당 proxy를 통해 외부로 통하게하는 구조로 개발 해야함
(fiddler의 override dns와 같은 기능)  

