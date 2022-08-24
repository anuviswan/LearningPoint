///
//  Generated code. Do not modify.
//  source: greet.proto
//
// @dart = 2.12
// ignore_for_file: annotate_overrides,camel_case_types,constant_identifier_names,deprecated_member_use_from_same_package,directives_ordering,library_prefixes,non_constant_identifier_names,prefer_final_fields,return_of_invalid_type,unnecessary_const,unnecessary_import,unnecessary_this,unused_import,unused_shown_name

import 'dart:core' as $core;
import 'dart:convert' as $convert;
import 'dart:typed_data' as $typed_data;
@$core.Deprecated('Use helloRequestDescriptor instead')
const HelloRequest$json = const {
  '1': 'HelloRequest',
  '2': const [
    const {'1': 'name', '3': 1, '4': 1, '5': 9, '10': 'name'},
  ],
};

/// Descriptor for `HelloRequest`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List helloRequestDescriptor = $convert.base64Decode('CgxIZWxsb1JlcXVlc3QSEgoEbmFtZRgBIAEoCVIEbmFtZQ==');
@$core.Deprecated('Use helloReplyDescriptor instead')
const HelloReply$json = const {
  '1': 'HelloReply',
  '2': const [
    const {'1': 'message', '3': 1, '4': 1, '5': 9, '10': 'message'},
  ],
};

/// Descriptor for `HelloReply`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List helloReplyDescriptor = $convert.base64Decode('CgpIZWxsb1JlcGx5EhgKB21lc3NhZ2UYASABKAlSB21lc3NhZ2U=');
@$core.Deprecated('Use readStatusRequestDescriptor instead')
const ReadStatusRequest$json = const {
  '1': 'ReadStatusRequest',
  '2': const [
    const {'1': 'id', '3': 1, '4': 1, '5': 5, '10': 'id'},
  ],
};

/// Descriptor for `ReadStatusRequest`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List readStatusRequestDescriptor = $convert.base64Decode('ChFSZWFkU3RhdHVzUmVxdWVzdBIOCgJpZBgBIAEoBVICaWQ=');
@$core.Deprecated('Use readStatusResponseDescriptor instead')
const ReadStatusResponse$json = const {
  '1': 'ReadStatusResponse',
  '2': const [
    const {'1': 'status', '3': 1, '4': 1, '5': 9, '10': 'status'},
  ],
};

/// Descriptor for `ReadStatusResponse`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List readStatusResponseDescriptor = $convert.base64Decode('ChJSZWFkU3RhdHVzUmVzcG9uc2USFgoGc3RhdHVzGAEgASgJUgZzdGF0dXM=');
@$core.Deprecated('Use rawDataRequestDescriptor instead')
const RawDataRequest$json = const {
  '1': 'RawDataRequest',
  '2': const [
    const {'1': 'maxItems', '3': 1, '4': 1, '5': 5, '10': 'maxItems'},
  ],
};

/// Descriptor for `RawDataRequest`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List rawDataRequestDescriptor = $convert.base64Decode('Cg5SYXdEYXRhUmVxdWVzdBIaCghtYXhJdGVtcxgBIAEoBVIIbWF4SXRlbXM=');
@$core.Deprecated('Use rawDataResponseDescriptor instead')
const RawDataResponse$json = const {
  '1': 'RawDataResponse',
  '2': const [
    const {'1': 'id', '3': 1, '4': 1, '5': 5, '10': 'id'},
    const {'1': 'description', '3': 2, '4': 1, '5': 9, '10': 'description'},
  ],
};

/// Descriptor for `RawDataResponse`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List rawDataResponseDescriptor = $convert.base64Decode('Cg9SYXdEYXRhUmVzcG9uc2USDgoCaWQYASABKAVSAmlkEiAKC2Rlc2NyaXB0aW9uGAIgASgJUgtkZXNjcmlwdGlvbg==');
