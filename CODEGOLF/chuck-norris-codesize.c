#include <stdio.h>
char M[999],*p=M,t[999],l='a',r,s=' ',z='0';
int y=0,x;
void main(){scanf("%[^\n]",M);while(*p!='\0'){x=7;while(x-->0){r=48+((*p>>x)&1);if(l!=r){if(y!=0)t[y++]=s;t[y++]=z;if(r=='0')t[y++]=z;t[y++]=s;}t[y++]=z;l=r;}p++;}t[y]='\0';printf("%s\n",t);}