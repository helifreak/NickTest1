﻿#!/usr/bin/python
import sys

#def Simple(foo):
#	print("Hello From Python Simple({0})".format(foo))
#	print "Call Dir(): "
#	print dir()
#	print "Print the Path: " 
#	print sys.path



#from BaseHTTPServer import BaseHTTPRequestHandler,HTTPServer
#import os
#from os import curdir, sep     
#import cgi
import json
 
#PORT_NUMBER = 8080  
import sys  
#6e00a83949416ac811b33156ab141cb241e9f552

def Simple(foo):
    json_data = foo 
    data = json.load(json_data)
    if 'refs/heads/master' in data:
        os.system("start bundle.sh")
        print ("master detected")
    elif 'red/heads/develep' in data:
        os.system("start update.sh")
        print ("develop detected")
    else:
        print("error with branch detection")
    print(foo)


#This class will handles any incoming request from
#the browser
#class myHandler(BaseHTTPRequestHandler):

        #Handler for the GET requests
 #       def do_GET(self):
  #              self.send_response(200)
   #             self.send_header('Content-type','text/html')
    #            self.end_headers()
                # Send the html message
     #           self.wfile.write("Hello World !")
      #          return

        #Handler for the POST requests
'''
        def do_POST(self):
                ctype, pdict = cgi.parse_header(self.headers.getheader('content-type'))
                if ctype == 'application/json':
                        length = int(self.headers.getheader('content-length'))
                        data = cgi.parse_qs(self.rfile.read(length), keep_blank_values=1)
                        os.system("cd MVRT_Site && git fetch --all && git reset --hard origin/master && grunt build")
'''
#        def do_POST(self):
 #               ctype, pdict = cgi.parse_header(self.headers.getheader('content-type'))
  #              if ctype == 'application/json':
   #                     json_data = open('application/json').read()
    #                    data = json.load(json_data)
     #                   if 'refs/heads/master' in data:
      #                          os.system("start bundle.sh")
       #                         print ("master detected")
        #                elif 'red/heads/develep' in data:
         #                       os.system("start update.sh")
          #                      print ("develop detected")
           #             else:
            #                    print("error with branch detection")
             #   else:
              #          print("error")
                                
                


#try:
	#Create a web server and define the handler to manage the
	#incoming request
 #       server = HTTPServer(('', PORT_NUMBER), myHandler)
  #      print ('Started httpserver on port ' , PORT_NUMBER)

	#Wait forever for incoming htto requests
   #     server.serve_forever()

#except KeyboardInterrupt:
 #       print ('^C received, shutting down the web server')
  #      server.socket.close()
