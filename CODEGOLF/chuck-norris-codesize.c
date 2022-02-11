#include <stdio.h>
char M[999], *p = M, t[999], c, s = ' ', z = '0';
int j=0,x,l=0,y=0,k;
void set() {
  if(c!='1')M[y++]=z;
  M[y++]=z;
  M[y++]=s;
  while(l-->0)M[y++]=z;
}
void main(){
  scanf("%[^\n]",M);
  while(*p!='\0'){x=7;while(x-->=0)t[j+6-x]=48+((*p>>x)&1);j+=7;p++;}
  k=j;t[j]='\0';j=0;c=t[j];
  while(j<=k){if(c==t[j])l++;else{if(y!=0)M[y++]=s;set();c=t[j];l=1;}j++;}
  M[y]='\0';printf("%s\n",M);
}