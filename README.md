# SAS custom task example: SAS Macro Variable Viewer and SAS System Options Viewer
***
This repository contains one of a series of examples that accompany
_Custom Tasks for SAS Enterprise Guide using Microsoft .NET_ 
by [Chris Hemedinger](http://support.sas.com/hemedinger).

This particular example goes with
**Chapter 17: Building a SAS Macro Variable Viewer and SAS System Options Viewer**.  It was built using C# 
with Microsoft Visual Studio 2010.  It should run in SAS Enterprise Guide 4.3 and later.

## About this example
Because these tasks share some common code, 
they are implemented in the same Visual Studio project. 
However, they were not developed at the same time!

The SAS Macro Variable Viewer was developed first. 
It was made available for download 
on [The SAS Dummy blog](http://blogs.sas.com/content/sasdummy/2011/11/22/inspecting-sas-macro-variables-in-sas-enterprise-guide/). 
As users downloaded the task and tried it out, they left 
comments on the blog with their suggested features. 
One astute user suggested that it would be useful to be 
able to view SAS system options as well, similar to what 
you see in the OPTIONS window in the SAS windowing environment. 

It was a good suggestion. A month later, an updated version of the task with 
this capability was available on the blog.

The chapter does not address every detail of these task 
implementations. Instead, it focuses on just the techniques 
and tricks that haven't been covered elsewhere in this book. For a 
complete view of the implementations, download the 
source projects and review them in Visual Studio.


