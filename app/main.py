from src.analyzer.analyzer import Analyzer
import argparse
import json
import sys
import os

def parse_arguments():
	parser = argparse.ArgumentParser()
	parser.add_argument("--filename", help="The filename to analyze.")
	parser.add_argument("--directory", help="The directory to analyze.")
	parser.add_argument("--settings", help="A settings file for custom execution.")
	args = parser.parse_args()
	settings = {
		"preprocessing" : {
			"clahe" : {
				"clip_limit": 1.5,
				"k_size": 10
			},
			"blur" : {
				"k_size": 3
			}
		},
		"analysis" : {
			"threshold" : {
				"max": 255,
				"min": 35
			}
		}
	}

	# Try to load the settings, if supplied it.
	if args.settings:
		try:
			json_data = open(args.settings).read()
			settings = json.loads(json_data)
		except Exception as e:
			print('[WARNING] Improper settings file, using defaults.')
			print(e)

	# Initialize the Analyzer
	analyzer = Analyzer(settings)

	# If the user entered a filename then analyze the file
	if args.filename:
		try:
			analyzer.analyze_image(args.filename)
		except Exception as e:
			print(e)
	try:
		if args.directory:
			try:
				analyzer.analyze_images_in_dir(args.directory)
				# analyzer.test_preprocessor(args.directory)
			except Exception as e:
				print(e)
	except Exception as e:
		print (e)



if __name__ == '__main__':
	parse_arguments()
