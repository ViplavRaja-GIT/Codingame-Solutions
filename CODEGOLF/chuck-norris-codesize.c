char M[99],*p=M,t[999],s=' ',z='0';
int y=0,x,l=2,r;
main(){scanf("%[^\n]",M);while(*p!='\0'){x=7;while(x-->0){r=((*p>>x)&1);if(l!=r){if(y)t[y++]=s;t[y++]=z;if(!r)t[y++]=z;t[y++]=s;}t[y++]=z;l=r;}p++;}t[y]='\0';printf("%s\n",t);}